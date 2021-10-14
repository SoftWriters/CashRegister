package Reader;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;


public class MoneyReader {
	
	private BufferedReader in;
	
	public MoneyReader(String fileName) throws FileNotFoundException {
		in = new BufferedReader(new FileReader(fileName));
	}
	
	public String readPayment() throws IOException {
		String line  = in.readLine();
		return  line;

	}
	
	public void close() throws IOException {
		in.close();
	}
}
