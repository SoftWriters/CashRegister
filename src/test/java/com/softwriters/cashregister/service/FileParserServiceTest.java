package com.softwriters.cashregister.service;

import static org.junit.jupiter.api.Assertions.assertNotEquals;

import java.io.File;
import java.io.IOException;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class FileParserServiceTest {

	private FlatFileParserService service;
	
	@BeforeEach
	public void initialize() {
		service = new FlatFileParserService();
	}
	
	@Test
	public void testDivisibleByThree() throws IOException {
		service = new FlatFileParserService();
		File file = service.processFile(new File("src/test/resources/DivisibleByThree.txt"));
		assertNotEquals(0, file.length());	
	}
	
	@Test
	public void testNormalChange() throws IOException {
		service = new FlatFileParserService();
		File file = service.processFile(new File("src/test/resources/NormalChange.txt"));
		assertNotEquals(0, file.length());	
	}
}
