/**
 * Generates a pseudo random integer between a range of zero to a given max integer.
 * @param {number} max - The max possible integer
 */
export const getRandomInt = (max: number): number => Math.floor(Math.random() * Math.floor(max));

/**
 * Converts a US currency string to cents as an integer
 * @param {string} currencyString - The currency string to convert
 */
export const convertToCents = 
    (currencyString: string) => parseInt(currencyString.replace(/\D/g, ''));
