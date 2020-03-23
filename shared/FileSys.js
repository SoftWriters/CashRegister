/*
Author: Greg Goodhile
*/

'use strict';

const fs = require( 'fs' );

/*
Read input file
path <String>
Returns <String>
*/
const readFile = ( path ) => {
	try {
		const data = fs.readFileSync( path, 'utf8' );
		return data.length > 0 ? data : null;
	} catch ( err ) {
		console.log( err.message );
		return null;
	}
};

/*
write output file
path <String>
Returns <String>
*/
const writeFile = ( path, data ) => {
	try {
		fs.writeFileSync( path, data, 'utf8' );
	} catch ( err ) {
		console.log( err.message );
		throw new Error( 'Cannot write output file' );
	}
};

module.exports = { readFile, writeFile };