//Enter file contents herepackage register;

import java.math.BigDecimal;
import java.util.Random;

public class CalculateChange 
{
	static final int[] moneyDenominations = new int[] {1,2,5,10,20,50,100};
	static final String[] moneyDenominationNames = new String[] {"One","Two","Five","Ten","Twenty","Fifty","Hundred"};
	//static final String[] moneyDenominationNamesSingle = new String[] {1,2,5,10,20,50,100};
	//static final String[] moneyDenominationNamesMultiple = new String[] {1,2,5,10,20,50,100};
	static final int[] coins = new int[] {1,5,10,25};
	static final String[] coinNameSingle = new String[] {"penny","nickel","dime","quarter"};
	static final String[] coinNameMultiple = new String[] {"pennies","nickels","dimes","quarters"};
	
	public CalculateChange()
	{
		
	}
	
	public String getChange(BigDecimal cost,BigDecimal cash)
	{
		String ret = null;
		BigDecimal change = cash.subtract(cost);
		String bds = change.toPlainString();
		int decimalLocation = bds.indexOf('.');
		int dollars;
		int cents;
		
		if(decimalLocation != -1)
		{
			cents = Integer.parseInt(bds.substring(decimalLocation + 1, bds.length()));
			
			if(decimalLocation != 0)
			{
				String temp = bds.substring(0, decimalLocation);			
				dollars = Integer.parseInt(bds.substring(0, decimalLocation));				
			}
			else
			{
				dollars = 0;
			}
			
		}
		else
		{
			dollars = Integer.parseInt(bds);
			cents = 0;
		}
		
		return getChange(dollars,cents,change);
	}
	
	private String getChange(int dollars, int cents, BigDecimal change)
	{
		boolean divisor_3_test = true;
		BigDecimal threeTest = new BigDecimal(3);
		String dollarAmt = null;
		String centAmt = null;		
		//System.out.println("change is " + change.toPlainString());
		BigDecimal test1 = null;
		String ret = "";
		
		try
		{
			test1 = change.divide(threeTest);
		}
		catch(ArithmeticException a)
		{
			divisor_3_test = false;
		}
		/*
		 * can it be divided by 3? sure anything can be divided by 3
		 * assumption: after dividing by 3 the result can be expressed in US money
		 */
		
		if(divisor_3_test)
		{
			
			if(dollars > 0)
			{
				dollarAmt = getDollarsRandom(dollars);
				//System.out.println("***3dollarAmt is " + dollarAmt + "***");
			}
			
			if(cents > 0)
			{
				centAmt = getCentsRandom(cents);
			}
			
		}
		else
		{
			
			if(dollars > 0)
			{
				dollarAmt = getDollars(dollars);
				//System.out.println("not random dollarAmt is " + dollarAmt + "***");
			}
			
			if(cents > 0)
			{
				centAmt = getCents(cents);
			}
			
		}
		
		//System.out.println("ret is " + dollarAmt + " " + centAmt);
		
		if(dollarAmt == null)
		{
			ret = centAmt;
		}
		
		if(centAmt == null)
		{
			ret = dollarAmt;
		}
		
		if(dollarAmt != null && centAmt != null)
		{
			ret = dollarAmt + ", " + centAmt;
		}
		
		return ret;		
	}
	
	private String getDollars(int dollars)
	{
		int stop = getDollarStopLevel(dollars);
		//System.out.println("non random stop is " + stop);
		return makeDollarChange(dollars,stop);
	}
	
	private String getDollarsRandom(int dollars)
	{
		int stop = getDollarStopLevel(dollars);
		//System.out.println("***8stop is " + stop + " 8***");
		String testRandom = makeDollarChangeRandom(dollars,stop);
		//System.out.println("testRandom is " + testRandom);
		return testRandom;
	}
	
	private String getCents(int cents)
	{
		int stop = getCentStopLevel(cents);
		//System.out.println("non random cents stop is " + stop);
		return makeCentChange(cents,stop);
	}
	
	private String getCentsRandom(int cents)
	{
		int stop = getCentStopLevel(cents);
		//System.out.println("cents random stop is " + stop);
		String centsRandom = makeCentChangeRandom(cents,stop);
		//System.out.println("centsRandom is " + centsRandom);
		return centsRandom;
	}
	
	private int getDollarStopLevel(int dollars)
	{
		int ret = -1;
		
		for(int a = 0;a < moneyDenominations.length;a++)
		{
			//System.out.println("a is " + a);
			//System.out.println("moneyDenominations.length is " + moneyDenominations.length);
			//System.out.println("moneyDenominations.length - 1 is " + (moneyDenominations.length - 1));
			
			if(moneyDenominations[a] == dollars )
			{
				ret = a;
				break;
			}			
			else if(a < (moneyDenominations.length - 1))
			{
			
				if(moneyDenominations[a + 1] > dollars)
				{
					ret = a;
					break;
				}
			
			}
			else if(a == (moneyDenominations.length -1))
			{
				ret = a;
			}
			
		}
		
		return ret;
	}
	
	private int getCentStopLevel(int cents)
	{
		int ret = -1;
		//System.out.println("cents is " + cents);
		
		for(int a = 0;a < coins.length;a++)
		{
			//System.out.println("coins[a] is " + coins[a]);
			
			if(coins[a] == cents )
			{
				ret = a;
				break;
			}			
			else if(a < (coins.length - 1))
			{
				//System.out.println("coins[a + 1] is " + coins[a + 1]);
			
				if(coins[a + 1] > cents)
				{
					ret = a;
					break;
				}
			
			}
			else if(a == (coins.length -1))
			{
				//System.out.println("coins[a] is " + coins[a]);
				ret = a;
			}
			
		}
		
		return ret;
	}
	
	private String makeDollarChange(int dollars, int stop)
	{
		int remaining = dollars;		
		int[] temp = new int[stop + 1];
		String ret = null;
		//int currentPlace = stop;
		
		for(int a = stop;a > -1;a--)
		{
			
			if(moneyDenominations[a] > remaining)
			{
				continue;
			}
			
			int counter = 0;
			int evenTest = remaining % moneyDenominations[a];
			
			if(evenTest == 0)
			{
				
				do
				{
					counter++;
					remaining -= moneyDenominations[a];					
				}while(remaining > 0);
				
				temp[a] = counter;
			}
			else
			{
				//temp[a] = 1;
				do
				{
					counter++;
					remaining -= moneyDenominations[a];					
				}while(remaining > moneyDenominations[a]);
				
				temp[a] = counter;
			}
			
		}
		
		ret = "";
		
		//for(int a = 0;a < temp.length;a++)
		for(int a = (temp.length -1);a > -1;a--)
		{
			
			if(temp[a] != 0)
			{
				
				if(temp[a] == 1)
				{
					ret += String.valueOf(temp[a]) + " " + moneyDenominationNames[a] + " dollar bill,";
				}
				else
				{
					ret += String.valueOf(temp[a]) + " " + moneyDenominationNames[a] + " dollar bills,";
				}
			}			
						
		}
		
		ret = ret.substring(0, ret.length()-1);		
		return ret;
	}
	
	private String makeDollarChangeRandom(int dollars, int stop)
	{
		//System.out.println("dollars is " + dollars);
		int remaining = dollars;		
		int[] temp = new int[stop + 1];
		String ret = null;
		int random = getRandomNumber(0,stop);
		//System.out.println("random is " + random);
		
		for(int a = stop;a > -1;a--)
		{
			int counter = 0;
			int evenTest = remaining % moneyDenominations[a];
			
			if(a == random)
			{
				//System.out.println("found random");
				
				if(evenTest == 0)
				{
					
					do
					{
						counter++;
						remaining -= moneyDenominations[a];					
					}while(remaining > 0);
					
					temp[a] = counter;
					//System.out.println("remaining even dollars is " + remaining);
				}
				else
				{
					
					do
					{
						counter++;
						remaining -= moneyDenominations[a];
					}while(remaining > moneyDenominations[a]);
					
					temp[a] = counter;
					//System.out.println("remaining dollars is " + remaining);
				}
			}			
			
		}
		//new
		for(int a = stop;a > -1;a--)
		{
			
			if(moneyDenominations[a] > remaining)
			{
				continue;
			}
			
			int counter = 0;
			int evenTest = remaining % moneyDenominations[a];
			//System.out.println("evenTest dollars is " + evenTest);
			
			if(a != random)
			{
				
				if(evenTest == 0)
				{
					
					do
					{
						counter++;
						remaining -= moneyDenominations[a];					
					}while(remaining > 0);
					
					temp[a] = counter;
					//System.out.println("remaining dollars not random even is " + remaining);
				}
				else
				{
					
					do
					{
						counter++;
						remaining -= moneyDenominations[a];
					}while(remaining > moneyDenominations[a]);
					
					temp[a] = counter;
					//System.out.println("remaining dollars not random is " + remaining);
				}
			}			
			
		}
		
		ret = "";
		
		//for(int a = 0;a < temp.length;a++)
		for(int a = (temp.length - 1);a > -1;a--)
		{
			
			if(temp[a] != 0)
			{
				
				if(temp[a] == 1)
				{
					ret += String.valueOf(temp[a]) + " " + moneyDenominationNames[a] + " dollar bill,";
				}
				else
				{
					ret += String.valueOf(temp[a]) + " " + moneyDenominationNames[a] + " dollar bills,";
				}
				
			}			
						
		}
		
		ret = ret.substring(0, ret.length()-1);
		return ret;
	}
	
	private String makeCentChange(int cents, int stop)
	{
		int remaining = cents;		
		int[] temp = new int[stop + 1];
		String ret = null;
		//int currentPlace = stop;
		
		for(int a = stop;a > -1;a--)
		{
			//System.out.println("cents not random remaining is " + remaining);
			//System.out.println("coins[a] is " + coins[a]);
			
			if(coins[a] > remaining)
			{
				//System.out.println("continuing");
				continue;
			}
			
			int counter = 0;
			int evenTest = remaining % coins[a];
			
			if(evenTest == 0)
			{
				
				do
				{
					counter++;
					remaining -= coins[a];					
				}while(remaining > 0);
				
				temp[a] = counter;
				//System.out.println("remaining even is " + remaining);
			}
			else
			{
				/*temp[a] = 1;
				remaining -= coins[a];*/
				do
				{
					counter++;
					remaining -= coins[a];					
				}while(remaining > coins[a]);
				
				temp[a] = counter;
				//System.out.println("remaining is " + remaining);
			}
			
		}
		
		ret = "";
		//for(int a = 0;a < temp.length;a++)
		for(int a = (temp.length - 1);a > -1;a--)
		{
			
			if(temp[a] > 0)
			{
				
				if(temp[a] == 1)
				{
					ret += String.valueOf(temp[a]) + " " + coinNameSingle[a] + ",";
				}
				else
				{
					ret += String.valueOf(temp[a]) + " " + coinNameMultiple[a] + ",";
				}
				
			}			
						
		}
		
		ret = ret.substring(0, ret.length()-1);
		return ret;
	}
	
	private String makeCentChangeRandom(int cents, int stop)
	{
		int remaining = cents;		
		int[] temp = new int[stop + 1];
		String ret = null;
		int random = getRandomNumber(0,stop);
		//System.out.println("random is " + random);
		//System.out.println("stop is " + stop);
		
		for(int a = stop;a > -1;a--)
		{
			//System.out.println("coins[a] is " + coins[a]);
			int counter = 0;
			
			if(a == random)
			{
				
				if(coins[a] > remaining)
				{
					continue;
				}
				
				//System.out.println("a is random");
				int evenTest = remaining % coins[a];
				//System.out.println("evenTest is " + evenTest);
				
				if(evenTest == 0)
				{
					
					do
					{
						counter++;
						remaining -= coins[a];	
						//System.out.println("remaining even 0 is " + remaining);
					}while(remaining > 0);
					
					temp[a] = counter;
				}
				else
				{
					
					do
					{
						counter++;
						remaining -= coins[a];
						//System.out.println("remaining is " + remaining);
					}while(remaining > coins[a]);
					
					temp[a] = counter;
				}
				
			}			
			
		}
		//new
		for(int a = stop;a > -1;a--)
		{
			//System.out.println("coins[a] is " + coins[a]);
			int counter = 0;
			
			if(a != random)
			{
				
				if(coins[a] > remaining)
				{
					continue;
				}
				
				int evenTest = remaining % coins[a];
				//System.out.println("evenTest is " + evenTest);
				
				if(evenTest == 0)
				{
					
					do
					{
						counter++;
						remaining -= coins[a];	
						//System.out.println("remaining even 0 is " + remaining);
					}while(remaining > 0);
					
					temp[a] = counter;
				}
				else
				{
					
					do
					{
						counter++;
						remaining -= coins[a];
						//System.out.println("remaining is " + remaining);
					}while(remaining > coins[a]);
					
					temp[a] = counter;
				}
				
			}			
			
		}
		
		ret = "";
		
		//for(int a = 0;a < temp.length;a++)
		for(int a = (temp.length - 1);a > -1;a--)
		{			
			//System.out.println("temp[a] is " + temp[a]);
			
			if(temp[a] > 0)
			{
				
				if(temp[a] == 1)
				{
					ret += String.valueOf(temp[a]) + " " + coinNameSingle[a] + ",";
				}
				else
				{
					//System.out.println("assigning ret");
					ret += String.valueOf(temp[a]) + " " + coinNameMultiple[a] + ",";
					//System.out.println("ret is " + ret);
				}
				
			}			
						
		}
		
		//System.out.println("ret is " + ret);
		
		if(ret != "")
		{
			ret = ret.substring(0, ret.length()-1);
		}
		
		return ret;
	}
	
	private int getRandomNumber(int min, int max)
	{
		Random r = new Random();
		return r.nextInt((max - min) + 1) + min;
	}

}
