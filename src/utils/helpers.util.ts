/**
 * Converts a US currency string to cents as an integer
 * @param {string} currencyString - The currency string to convert
 */
export const convertToCents = 
    (currencyString: string): number => parseInt(currencyString.replace(/\D/g, ''));
