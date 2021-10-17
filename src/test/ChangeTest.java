package test;

import static org.junit.Assert.*;
import java.text.DecimalFormat;
import Register.Change;
import org.junit.jupiter.api.Test;

class ChangeTest {

	@Test
	void testHundredsNoRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.hundreds(100.00);
		
		assertEquals(0.0,result,0.0);
	}
	
	@Test
	void testHundredsRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.hundreds(150.00);
		
		assertEquals(50.0,result,0.0);
	}
	
	@Test
	void testNoHundreds() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.hundreds(99.00);
		
		assertEquals(99.0,result,0.0);
	}
	
	@Test
	void testFiftiesNoRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.fifties(50.00);
		
		assertEquals(0.0,result,0.0);
	}
	
	@Test
	void testFiftiesRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.fifties(60.00);
		
		assertEquals(10.0,result,0.0);
	}
	
	@Test
	void testNoFifties() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.fifties(49.00);
		
		assertEquals(49.0,result,0.0);
	}
	
	@Test
	void testTwentiesNoRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.twenties(20.00);
		
		assertEquals(0.0,result,0.0);
	}
	
	@Test
	void testTwentiesRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.twenties(30.00);
		
		assertEquals(10.0,result,0.0);
	}
	
	@Test
	void testNoTwenties() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.twenties(15.00);
		
		assertEquals(15.0,result,0.0);
	}
	
	@Test
	void testTensNoRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.tens(100.00);
		
		assertEquals(0.0,result,0.0);
	}
	
	@Test
	void testTensRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.tens(25.00);
		
		assertEquals(5.0,result,0.0);
	}
	
	@Test
	void testNoTens() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.tens(9.00);
		
		assertEquals(9.0,result,0.0);
	}
	
	@Test
	void testFivesNoRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.fives(10.00);
		
		assertEquals(0.0,result,0.0);
	}
	
	@Test
	void testFivesRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.fives(11.00);
		
		assertEquals(1.0,result,0.0);
	}
	
	@Test
	void testNoFives() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.fives(4.00);
		
		assertEquals(4.0,result,0.0);
	}
	
	@Test
	void testOnesNoRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.ones(1.00);
		
		assertEquals(0.0,result,0.0);
	}
	
	@Test
	void testOnesRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.ones(1.50);
		
		assertEquals(0.50,result,0.0);
	}
	
	@Test
	void testNoOnes() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.ones(0.99);
		
		assertEquals(0.99,result,0.0);
	}

	@Test
	void testQuartersNoRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.quarters(0.50);
		
		assertEquals(0.0,result,0.0);
	}
	
	@Test
	void testQuartersRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.quarters(0.51);
		
		assertEquals(0.01,result,0.0);
	}
	
	@Test
	void testNoQuarters() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.quarters(0.24);
		
		assertEquals(0.24,result,0.0);
	}
	
	@Test
	void testDimesNoRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.dimes(0.90);
		
		assertEquals(0.0,result,0.0);
	}
	
	@Test
	void testDimesRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.dimes(0.95);
		
		assertEquals(0.05,result,0.0);
	}
	
	@Test
	void testNoDimes() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.dimes(0.09);
		
		assertEquals(0.09,result,0.0);
	}
	
	@Test
	void testNickelsNoRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.nickels(0.15);
		
		assertEquals(0.0,result,0.0);
	}
	
	@Test
	void testNickelsRemainder() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.nickels(0.16);
		
		assertEquals(0.01,result,0.0);
	}
	
	@Test
	void testNoNickels() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.nickels(0.04);
		
		assertEquals(0.04,result,0.0);
	}
	
	@Test
	void testPennies() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.pennies(0.10);
		
		assertEquals(0.0,result,0.0);
	}
	
	@Test
	void testNoPennies() {
		DecimalFormat df = new DecimalFormat("#.##");
		Change change = new Change(df);
		double result = change.pennies(0.00);
		
		assertEquals(0.0,result,0.0);
	}

}
