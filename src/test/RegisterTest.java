package test;


import static org.junit.Assert.*;

import java.io.IOException;
import java.util.ArrayList;

import org.junit.jupiter.api.Test;

import Register.Register;

/*
 * Test class for Register Class
 */
class RegisterTest {

	@Test
	void testPayments() throws IOException {
		Register register = new Register();
		ArrayList<Double> change = register.payments("Input.txt");
		int len = change.size();
		
		assertEquals(10,len);
	}
	
	@Test
	void testOutPutChangeBills() throws IOException {
		Register register = new Register();
		String output = register.outputChange(186.00);
		String result = "1 HUNDRED(S). 1 FIFTIES. 1 TWENTIES. 1 TEN(S). 1 FIVE(S). 1 ONE(S). ";
		assertTrue(output.equals(result));
	}
	
	@Test
	void testOutPutChangeCents() throws IOException {
		Register register = new Register();
		String output = register.outputChange(0.41);
		String result = "1 QUARTER(S). 1 DIME(S). 1 NICKEL(S). 1 PENNIES. ";
		assertTrue(output.equals(result));
	}

}
