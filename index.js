/*
Creative Cash Draw Solutions - Cash Register (demo program for SoftWriters)
https://github.com/SoftWriters/CashRegister

CLIENT GOALS / REQUIREMENTS
Please write a program which accomplishes the clients goals. The program should:
  * Accept a flat file as input
    * Each line will contain the total due and the amount paid separated by a comma (for example: 2.13,3.00)
    * Expect that there will be multiple lines
  * Output the change the cashier should return to the customer
    * The return string should look like: 1 dollar,2 quarters,1 nickel, etc ...
    * Each new line in the input file should be a new line in the output file


Author: Greg Goodhile

TECHNOLOGIES
  Node
  JavaScript

TO RUN
  node index.js  -OR-  npm run start

*/

'use strict';

( () => {

  const { readFile, writeFile } = require( './shared/FileSys' );
  const { parseRecords, makeChangePhrase } = require( './shared/ChangeBuilder' );

  const inputDataPath = './records/due-paid.csv';
  const outDataPath = './records/change.csv';

  const inputData = readFile( inputDataPath );

  if ( inputData ) {
    try {
      // parse records from input file as amount due and amount paid; values converted to cents
      const inputRecords = parseRecords( inputData );
      // create output records in the form of comma-separated change denomination phrases
      const outputRecords = inputRecords.map( makeChangePhrase );
      // convert records array to a string with a newline character after each record
      const outData = outputRecords.join( '\n' );

      writeFile( outDataPath, outData );
      console.log( 'Output file written' );
    } catch ( err ) {
      console.log( err.message );
    }
  } else {
    console.log( 'No data to retrieve' );
  }

} )();
