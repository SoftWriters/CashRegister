/**
 * Strips all non-digit characters from a currency string
 * @param {string} currencyString - The currency string to convert
 * @returns Digit characters from string as an integer
 */
export const currencyStringToInt = 
    (currencyString: string): number => parseInt(currencyString.replace(/\D/g, ''));
