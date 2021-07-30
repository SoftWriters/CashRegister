import { currencyStringToInt } from './helpers.util';

describe('Helper utilities', () => {
    describe('currencyStringToInt', () => {
        test('should strip all non digit characters from given currency string, and return as an int', () => {
            expect(currencyStringToInt('$100.33')).toEqual(10033);
            expect(currencyStringToInt('$1,234.56')).toEqual(123456);
            expect(currencyStringToInt('$0.56')).toEqual(56);
            expect(currencyStringToInt('d$12343.5438,3fsdf')).toEqual(1234354383);
        });
    });
});
