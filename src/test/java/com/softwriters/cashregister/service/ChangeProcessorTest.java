package com.softwriters.cashregister.service;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertNotNull;

import java.math.BigDecimal;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class ChangeProcessorTest {

	private ChangeProcessingService changeProcessingService;
	
	@BeforeEach
	public void initialize() {
		changeProcessingService = new ChangeProcessingService();
	}
	
	@Test
	public void randomChangeTest() {
		assertNotNull(changeProcessingService.calculateRandomChange(new BigDecimal("3.33"), new BigDecimal("5.00")));
	}
	
	@Test
	public void normalChangeTest() {
		assertEquals("1 dollar,3 quarters,2 pennies,", changeProcessingService.calculateChange(new BigDecimal("3.23"), new BigDecimal("5.00")));
	}
	
	@Test
	public void normalLargeChangeTest() {
		assertEquals("1 fifty dollar bill,1 ten dollar bill", changeProcessingService.calculateChange(new BigDecimal("40.00"), new BigDecimal("100.00")));
	}
	
	@Test
	public void randomLargeChangeTest() {
		assertNotNull(changeProcessingService.calculateRandomChange(new BigDecimal("333"), new BigDecimal("400")));
	}
}
