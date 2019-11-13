package com.kuhn.cashRegisterTest;

import org.junit.Test;
import static org.junit.Assert.*;
import com.kuhn.cashRegister.*;

/**
 * This is a sample unit test of getBasicChange
 * @author 	Sean Kuhn
 * @Date	11/7/2019
 *
 */
public class UnitTest {
	
	@Test
	public void testGetBasicChange() {
		Till tillUnitTest = new Till();
		String result = tillUnitTest.getBasicChange(2337);

		assertEquals("1 twenty, 3 dollars, 1 quarter, 1 dime, 2 pennies", result);

	}
	
	@Test
	public void testTransaction() {
		Till tillUnitTest = new Till();
		String result = "";
		try {
			result = tillUnitTest.transaction(26.63,50.00);
		} catch (Exception e) {
			e.printStackTrace();
		}

		assertEquals("1 twenty, 3 dollars, 1 quarter, 1 dime, 2 pennies", result);

	}
}
