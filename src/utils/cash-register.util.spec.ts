import { US_DENOMS_BY_CENTS, calculateChange } from './cash-register.util';
import { USCurrencyDenom } from '../enums/us-currency-denom.enum';

describe('Cash Register utility', () => {
    const convertDenomsToChange = ((changeMap: Map<string, number>): number => {
        let change = 0;

        [...changeMap].map(([ name, qty ]) => {
            const denomValue = US_DENOMS_BY_CENTS.find(d => d.name === name).value;
            change += denomValue * qty;
        });

        return change;
    });

    test('returns null if amount paid does not cover total due', () => {
        expect(calculateChange(2800, 700)).toBeNull();
    });

    test('throws a warning if totalDue and/or amountPaid are not integers', () => {
        const warnMsg = 'CashRegister: totalDue/amountPaid are not integers! Results may not be what is expected.';
        const consoleWarnSpy = jest.spyOn(console, 'warn').mockImplementation(() => {});

        calculateChange(28.05, 123);
        expect(consoleWarnSpy).toHaveBeenCalledWith(warnMsg);

        consoleWarnSpy.mockClear();

        calculateChange(28, 123.12);
        expect(consoleWarnSpy).toHaveBeenCalledWith(warnMsg);

        consoleWarnSpy.mockClear();

        calculateChange(28.345, 123.12);
        expect(consoleWarnSpy).toHaveBeenCalledWith(warnMsg);

        consoleWarnSpy.mockClear();

        calculateChange(28, 123);
        expect(consoleWarnSpy).not.toHaveBeenCalled();
    });

    describe('when the total change due in cents is divisible by three', () => {
        const changeDenomQtysAreDifferent = (currMap: Map<string, number>, prevMap: Map<string, number>): boolean => {
            const currMapQtys = [...currMap].map(([denom, qty]) => qty);
            const prevMapQtys = [...prevMap].map(([denom, qty]) => qty);
    
            for (let i = 0; i < currMapQtys.length; i++) {
                if (currMapQtys[i] !== prevMapQtys[i]) {
                    return true;
                }
            }
    
            return false;
        };

        /**
         * Make change twice, and assert the change generated is correct each time.
         * Then, compare the denom qtys from both sets of change, and assert that they're different.
         * 
         * In theory, there is a very small chance the change qtys could be the same both times...
         * Given the possible denom combinations in the test cases we're using, it seems unlikely to happen.
         * Just worth noting here, though. Not sure how to best address that given the nature of the requirements.
         */
        const assertRandomDenoms = (totalDue: number, amountPaid: number): void => {
            let previousChangeMap: Map<string, number>;
            let changeMap: Map<string, number> = calculateChange(totalDue, amountPaid);

            expect(convertDenomsToChange(changeMap)).toEqual(amountPaid - totalDue);

            previousChangeMap = changeMap;

            changeMap = calculateChange(totalDue, amountPaid);

            expect(convertDenomsToChange(changeMap)).toEqual(amountPaid - totalDue);
            expect(changeDenomQtysAreDifferent(changeMap, previousChangeMap)).toBe(true);
        };

        test('returns random sets of denominations that give correct change', () => {
            // 50.68 - 25.00 = 25.68
            assertRandomDenoms(2500, 5068);

            // 4.33 - 0.34 = 3.99
            assertRandomDenoms(34, 433);

            // 1253.54 - 560.30 = 693.24
            assertRandomDenoms(56030, 125354);
        });
    });

    describe('when the total change due in cents is not divisible by three', () => {
        const assertNormalDenoms = (
            totalDue: number, 
            amountPaid: number, 
            expectedChangeMap: Map<string, number>
        ): void => {
            let changeMap = calculateChange(totalDue, amountPaid);
            expect(convertDenomsToChange(changeMap)).toEqual(amountPaid - totalDue);
            expect(changeMap).toEqual(expectedChangeMap);
        };

        test('returns expected static sets of denominations that give correct change', () => {
            // 28.00 - 7.59 = 20.41
            assertNormalDenoms(759, 2800, new Map([
                [USCurrencyDenom.Dollar, 20],
                [USCurrencyDenom.Quarter, 1],
                [USCurrencyDenom.Dime, 1],
                [USCurrencyDenom.Nickel, 1],
                [USCurrencyDenom.Penny, 1]
            ]));

            // 1.00 - .63 = .37
            assertNormalDenoms(63, 100, new Map([
                [USCurrencyDenom.Dollar, 0],
                [USCurrencyDenom.Quarter, 1],
                [USCurrencyDenom.Dime, 1],
                [USCurrencyDenom.Nickel, 0],
                [USCurrencyDenom.Penny, 2]
            ]));

            // 621.40 - 139.52 = 481.88
            assertNormalDenoms(13952, 62140, new Map([
                [USCurrencyDenom.Dollar, 481],
                [USCurrencyDenom.Quarter, 3],
                [USCurrencyDenom.Dime, 1],
                [USCurrencyDenom.Nickel, 0],
                [USCurrencyDenom.Penny, 3]
            ]));
        });
    });
});
