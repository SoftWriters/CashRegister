/*
Author: Greg Goodhile
*/

'use strict';

/*
Parse data as a list of records and evaluate the change owed back to customer.
data <String>
Returns <Array>
*/
const parseRecords = ( data ) => {
	// Convert "number" string into cents/pennies; this removes a decimal point from the string; no need to worry about math precision using float numbers.
	// Removing decimal from "number" string emulates multiplying a number by 100 to get cents/pennies.
	// v <String>
	// Returns <Number> | <NaN>
	const toCents = ( v ) => {
		// length must be at least 3 which signifies a valid currency decimal, ex: .45
		// if a decimal is not found two places from the right, v is not an expected currency value
		const vlen = v.length;
		if ( vlen < 3 || v.indexOf( '.' ) !== vlen - 3 ) {
			return NaN;
		}

		return Number( v.replace( '.', '' ) );
	};

	let recordList = [];
	let dataLine = 1;
	for ( const record of data.split( /\r?\n/ ) ) {
		const recordSet = record.split( ',' );
		if ( recordSet.length !== 2 ) {
			throw new Error( `Invalid record set at line ${dataLine} : missing two values separated by a comma.` );
		}

		const due = toCents( recordSet[ 0 ] );
		const paid = toCents( recordSet[ 1 ] );

		if ( Number.isNaN( due ) || Number.isNaN( paid ) ) {
			throw new Error( `Invalid record set at line ${dataLine} : invalid float value found while parsing.` );
		}

		if ( paid < due ) {
			throw new Error( `Invalid record set at line ${dataLine} : amount paid is less than amount due.` );
		}
		// calculate the change owed
		recordList.push( paid - due );
		dataLine++;
	}

	return recordList;
};

/*
	Create a comma-separated change denomination phrase
	cents <Number>
	Returns <String>
*/
const makeChangePhrase = ( cents ) => {
	// Mapping for change quantity phrases
	const phraseMap = {
		noun100: ( qty ) => {
			if ( qty === 0 ) return '';
			return qty === 1 ? '1 dollar,' : `${qty} dollars,`;
		},
		noun25: ( qty ) => {
			if ( qty === 0 ) return '';
			return qty === 1 ? '1 quarter,' : `${qty} quarters,`;
		},
		noun10: ( qty ) => {
			if ( qty === 0 ) return '';
			return qty === 1 ? '1 dime,' : `${qty} dimes,`;
		},
		noun5: ( qty ) => {
			if ( qty === 0 ) return '';
			return qty === 1 ? '1 nickel,' : `${qty} nickels,`;
		},
		noun1: ( qty ) => {
			if ( qty === 0 ) return '';
			return qty === 1 ? '1 penny,' : `${qty} pennies,`;
		}
	};

	// get cent count at centSize and leftOver cents
	const denominationMap = ( leftOver, centSize ) => {
		return {
			centSize,
			leftOver: leftOver % centSize,
			count: Math.floor( leftOver / centSize )
		};
	};

	// order of change denominations
	let denomOrderList = [ 100, 25, 10, 5, 1 ];

	// "DIVISIBLE BY 3 ~ TWIST CHECK"
	if ( cents % 3 === 0 ) {
		// shuffle denomOrderList
		let tmpOrder = [];
		for ( let i = denomOrderList.length - 1; i >= 0; i-- ) {
			const randIndex = Math.floor( Math.random() * ( i + .99 ) );
			tmpOrder.push( denomOrderList[ randIndex ] );
			denomOrderList.splice( randIndex, 1 );
		}
		denomOrderList = tmpOrder;
	}

	// list of change mappings
	let changeList = denomOrderList.map( ( v ) => {
		let tmpCounter = denominationMap( cents, v );
		cents = tmpCounter.leftOver;
		return tmpCounter;
	} );

	let phrase = phraseMap.noun100( changeList.find( v => v.centSize === 100 ).count );
	phrase += phraseMap.noun25( changeList.find( v => v.centSize === 25 ).count );
	phrase += phraseMap.noun10( changeList.find( v => v.centSize === 10 ).count );
	phrase += phraseMap.noun5( changeList.find( v => v.centSize === 5 ).count );
	phrase += phraseMap.noun1( changeList.find( v => v.centSize === 1 ).count );

	return phrase.slice( 0, -1 );
};

module.exports = { parseRecords, makeChangePhrase };