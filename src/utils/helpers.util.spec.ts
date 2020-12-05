import { convertToCents } from './helpers.util';

describe('Helper utilities', () => {
    describe('convertToCents', () => {
        test('should strip all non digit characters from given currency string, and return as an int', () => {
            expect(convertToCents('$100.33')).toEqual(10033);
            expect(convertToCents('$1,234.56')).toEqual(123456);
            expect(convertToCents('$0.56')).toEqual(56);
        });
    });
});
