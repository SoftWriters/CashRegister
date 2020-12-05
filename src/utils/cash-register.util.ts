import { getRandomInt } from './helpers.util';
import { USCurrencyDenom } from '../enums/us-currency-denom.enum';

interface Denom {
    name: string;
    value: number;
}

/**
 * Const array representing US currency denominations.
 * Values are in cents to avoid floating point rounding weirdness.
 */
export const US_DENOMS_BY_CENTS: Denom[] = [
    { name: USCurrencyDenom.Dollar, value: 100 },
    { name: USCurrencyDenom.Quarter, value: 25 },
    { name: USCurrencyDenom.Dime, value: 10 },
    { name: USCurrencyDenom.Nickel, value: 5 },
    { name: USCurrencyDenom.Penny, value: 1 }
];

/**
 * Calculates change from amount paid for a given total due. CALCULATIONS DONE IN US CENTS.
 * 
 * Starts from max given currency denomination (denom) and progresses through to min denom.
 * e.g. for US: dollar -> quarter -> dime -> nickel -> penny
 * 
 * @param {number} totalDue - The total amount due, in US cents.
 * @param {number} amountPaid - The amount paid, in US cents.
 * 
 * @returns {Map<string, number> | null} Map of change denoms by qty, null if amount paid is not sufficient.
 */
const calculateChange = (totalDue: number, amountPaid: number): Map<string, number> | null => {
    const denoms: Denom[] = Object.assign([], US_DENOMS_BY_CENTS);
    const changeMap: Map<string, number> = new Map(denoms.map(d => [d.name, 0]));
    let remainingChange: number = amountPaid - totalDue;

    // Randomize the denom qty if change is divisible by 3.
    let randomizeDenomQty = remainingChange % 3 === 0;

    // If totalDue/amountPaid aren't ints, throw a warning.
    if (totalDue % 1 !== 0 || amountPaid % 1 !== 0) {
        console.warn('CashRegister: totalDue/amountPaid are not integers! Results may not be what is expected.');
    }

    // If the item isn't fully paid for, return null.
    if (remainingChange < 0) {
        return null;
    }

    // Generate change for each denom (highest to lowest). Stop when no denoms left.
    while (denoms.length) {
        const denom = denoms.shift();

        // Don't randomize for the lowest denom as it should always make up the remaining difference in change.
        const denomQty = getDenomQtyForChange(
            remainingChange, 
            denom,
            randomizeDenomQty && !!denoms.length
        );
        
        // Update change Map with denom qty.
        changeMap.set(denom.name, denomQty);

        // If denomQty is truthy, calculate remaining change with denom qty and value.
        remainingChange = denomQty ? 
            remainingChange - (denom.value * denomQty) : 
            remainingChange;
    }

    return changeMap;
}

/**
 * For a given currency denomination (denom), 
 * calculate and return the max possible denom qty based on change amount given.
 * 
 * e.g. max possible US denom qtys for 2.50. two dollars, six quarters, fifteen dimes, 50 nickels, 250 pennies.
 * 
 * If randomizing denom qty, return a denom qty between 0 and the max possible denom qty.
 * Otherwise, return max possible qty aka give change the usual way.
 * 
 * @param {number} change - The amount of change expected.
 * @param {number} denom - The currency denomination to use for giving change.
 * @param {boolean} randomizeDenomQty - Determines whether to randomize the denom qty or not.
 * 
 * @returns {number} The denom qty to use.
 */
const getDenomQtyForChange = (change: number, denom: Denom, randomizeDenomQty: boolean): number => {
    const maxPossible = Math.floor(change / denom.value);
    return randomizeDenomQty ? getRandomInt(maxPossible) : maxPossible;
}

export { calculateChange }
