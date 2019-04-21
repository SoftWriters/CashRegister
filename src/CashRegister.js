/**
 * This is a Cash redister application that will take inputs from a file,
 * calculate the correct amount due and collect the correct change.
 *
 * by Zach Archer
 */

// Getting required node module for file I/O
const fs = require('fs');

// Initializing final print string. Will contain all final output
let finalPrintString = '';

// Getting input from file
const input = fs.readFileSync('./src/input.txt', 'utf-8');
const inputByLine = input.split('\n');

// Processing each input
inputByLine.forEach((inputPairs) => {
  getAmountOwed(inputPairs)
    .then((amount) => {
      getCorrectChange(amount)
        .then((finalChangeMap) => {
          setPrintString(finalChangeMap);
        });
    })
    // This catches if not enough money was inpute
    .catch((reason) => {
      finalPrintString += reason;
      fs.writeFileSync('./src/output.txt', finalPrintString);
      finalPrintString += '\n';
    });
});

/**
 * Takes two input values and returns an amount owed.
 * The first input values is the total bill and the second value is the money provided.
 *
 * Returns a promis of the amount due. Will Reject if Not enough money is provided.
 *
 * @param {*} inputPairs
 */
function getAmountOwed(inputPairs) {
  return new Promise((resolve, reject) => {
    // Pulls input values in to an array
    const values = inputPairs.split(',');
    // Calculates total amount to be returned
    const amount = values[1] - values[0];
    // If amount is less than zero. Not enough money was provided
    if (amount < 0) {
      reject('Not Enough Money');
    }
    resolve(amount);
  });
}

/**
 * Takes an amount of money owed and creates a map of change to be provided.
 *
 * Returns a promise of the map of change.
 *
 * @param {int} amountOwed
 */
function getCorrectChange(amountOwed) {
  return new Promise((resolve) => {
    const finalChangeMap = new Map();

    // Creating array of all denominations
    let denominations = [100, 50, 20, 10, 5, 1, 0.25, 0.10, 0.05, 0.01];

    // If the amount is divisible by 3 then randomize the array to randomize the change due.
    if (amountOwed % 3 === 0) {
      denominations = randomizeArray(denominations);
    }

    denominations.forEach((each) => {
      let num = amountOwed / each;

      num = Math.trunc(num);

      // As change is collected remove from total amount due
      const temp = amountOwed - (num * each);

      // Rounding amount owed to two decimal placed
      amountOwed = temp.toFixed(2);

      // Adding change collected to map.
      if (num > 0) {
        finalChangeMap.set(each, num);
      }
    });
    resolve(finalChangeMap);
  });
}

/**
 * Takes an mapped array of change due and creates a human readable printout string.
 *
 * @param {map} finalChangeMap
 */
function setPrintString(finalChangeMap) {
  finalChangeMap.forEach((value, key) => {
    // Getting human readable output
    let readableValue = '';
    switch (key) {
      default:
        break;
      case 100:
        readableValue = 'Hundered';
        if (value > 1) readableValue = 'Hundereds';
        break;
      case 50:
        readableValue = 'Fifty';
        if (value > 1) readableValue = 'Fifties';
        break;
      case 20:
        readableValue = 'Twenty';
        if (value > 1) readableValue = 'Twenties';
        break;
      case 10:
        readableValue = 'Ten';
        if (value > 1) readableValue = 'Tens';
        break;
      case 5:
        readableValue = 'Five';
        if (value > 1) readableValue = 'Fives';
        break;
      case 1:
        readableValue = 'Dollar';
        if (value > 1) readableValue = 'Dollars';
        break;
      case 0.25:
        readableValue = 'Quarter';
        if (value > 1) readableValue = 'Quarters';
        break;
      case 0.10:
        readableValue = 'Dime';
        if (value > 1) readableValue = 'Dimes';
        break;
      case 0.05:
        readableValue = 'Nickel';
        if (value > 1) readableValue = 'Nickels';
        break;
      case 0.01:
        readableValue = 'Penny';
        if (value > 1) readableValue = 'Pennies';
    }
    // Adding results to print string
    finalPrintString += `${value} ${readableValue}, `;
  });
  // Remove ", " from end for better formatting
  finalPrintString = finalPrintString.substr(0, finalPrintString.length - 2);

  // Print to output file
  fs.writeFileSync('./src/output.txt', finalPrintString);
  finalPrintString += '\n';
}

/**
 * This function takes in an array and returns a new array with same values only in a random order
 *
 * @param {array} array
 */
function randomizeArray(array) {
  let currentIndex = array.length;
  let temporaryValue;
  let randomIndex;

  // While there remain elements to shuffle...
  while (currentIndex !== 0) {
    // Pick a remaining element...
    randomIndex = Math.floor(Math.random() * currentIndex);
    currentIndex -= 1;

    // And swap it with the current element.
    temporaryValue = array[currentIndex];
    array[currentIndex] = array[randomIndex];
    array[randomIndex] = temporaryValue;
  }

  return array;
}

// Exporting all functions so test file can access and run assertion test
module.exports.getAmountOwed = getAmountOwed;
module.exports.getCorrectChange = getCorrectChange;
module.exports.randomizeArray = randomizeArray;
module.exports.setPrintString = setPrintString;
