//
//  ChangeCalculator.m
//  CashRegister
//
//  Created by  Robert Dohner on 12/14/16.
//  Copyright © 2016 SoftWriters. All rights reserved.
//

#import "ChangeCalculator.h"
#import <math.h>
#import <stdlib.h>

@implementation ChangeCalculator

NSString *const kCoinNameDollar = @"dollar";
NSString *const kCoinNameQuarter = @"quarter";
NSString *const kCoinNameDime = @"dime";
NSString *const kCoinNameNickel = @"nickel";
NSString *const kCoinNamePenny = @"penny";

int const kCoinValueDollar = 100;
int const kCoinValueQuarter = 25;
int const kCoinValueDime = 10;
int const kCoinValueNickel = 5;
int const kCoinValuePenny = 1;

NSString *const kNoChange = @"No change required";
NSString *const kMoreMoney = @"Please provide more money";

-(id)init {
    
    if (self = [super init]) {
        
        coinNameArray = [[NSArray alloc] initWithObjects:kCoinNameDollar, kCoinNameQuarter, kCoinNameDime, kCoinNameNickel, kCoinNamePenny, nil];
        coinValueArray = [[NSArray alloc] initWithObjects:[NSNumber numberWithInt:kCoinValueDollar], [NSNumber numberWithInt:kCoinValueQuarter], [NSNumber numberWithInt:kCoinValueDime], [NSNumber numberWithInt:kCoinValueNickel], [NSNumber numberWithInt:kCoinValuePenny], nil];
        
    }
    return self;
}

-(NSString *)calculateChange:(NSString *)inputString {
    
    [self initializeChangeArray];
    [self parseInput: inputString];
    
    if (amountOwed == amountGiven) {
        
        return kNoChange;
        
    } else if (amountOwed > amountGiven) {
        
        return kMoreMoney;
        
    } else if ((amountOwed % 3) == 0) {
        
        return [self calculateRandomChange];
        
    } else {
        
        return [self calculateBestChange];
    }
}

-(void)initializeChangeArray {
    
    changeArray = [[NSMutableArray alloc] initWithObjects:[NSNumber numberWithInteger:0], [NSNumber numberWithInteger:0], [NSNumber numberWithInteger:0], [NSNumber numberWithInteger:0], [NSNumber numberWithInteger:0], nil];
}

// Separates the amount owed from the amount given
-(void)parseInput:(NSString *)inputString {
    
    NSArray *floatArray = [inputString componentsSeparatedByString:@","];
    amountOwed = [self convertStringToInt:[floatArray objectAtIndex:0]];
    amountGiven = [self convertStringToInt:[floatArray objectAtIndex:1]];
}

// Converts the string to an int.  We use int to avoid floating point inaccuracies.
-(int)convertStringToInt:(NSString *)floatString {
    
    return [[floatString stringByReplacingOccurrencesOfString:@"." withString:@""] intValue];
}

-(NSString *)calculateBestChange {
    
    int change = amountGiven - amountOwed;
    int currentCoin = 0;            // The current coin we are calculating against
    
    while (change != 0) {
        
        if (change >= [[coinValueArray objectAtIndex:currentCoin] intValue]) {
            
            change = [self decreaseAmountOwed:change andIncreaseCoin:currentCoin];
            
        } else {
            
            currentCoin++;
            
        }
    }
    
    return [self createChangeString];
}

-(NSString *)calculateRandomChange {
    
    int change = amountGiven - amountOwed;
    
    while (change != 0) {
        
        int randomCoin = arc4random_uniform(5);
        if (change >= [[coinValueArray objectAtIndex:randomCoin] intValue]) {
            
            change = [self decreaseAmountOwed:change andIncreaseCoin:randomCoin];
        }
    }
    
    return [self createChangeString];
}

-(int)decreaseAmountOwed:(int)owed andIncreaseCoin:(int)coin {
    
    NSNumber *currentAmount = [changeArray objectAtIndex:coin];
    currentAmount = [NSNumber numberWithInt:[currentAmount intValue] + 1];
    [changeArray replaceObjectAtIndex:coin withObject:currentAmount];
    return owed - [[coinValueArray objectAtIndex:coin] intValue];
}

-(NSString *)createChangeString {
    
    NSString *changeString = @"";
    
    for (int i = 0; i < changeArray.count; i++) {
        
        if ([[changeArray objectAtIndex:i] intValue] != 0) {
            
            changeString = [changeString stringByAppendingString:[NSString stringWithFormat:@"%@ %@,", [changeArray objectAtIndex:i], [self getSingularOrPluralOfCoin:i usingValue:[changeArray objectAtIndex:i]]]];
        }
    }
    
    return [changeString substringToIndex:changeString.length - 1];
}

-(NSString *)getSingularOrPluralOfCoin:(int)coin usingValue:(NSNumber *)value {
    
    if ([value intValue] == 1) {
        
        // Return singular
        return [coinNameArray objectAtIndex:coin];
        
    } else {
        
        if (coin == 4) {
            
            // Remove the "y" in penny and add an "ies"
            NSString *tempString = [coinNameArray objectAtIndex:coin];
            tempString = [tempString substringToIndex:tempString.length - 1];
            return [tempString stringByAppendingString:@"ies"];
            
        } else {
            
            // Return plural
            return [[coinNameArray objectAtIndex:coin] stringByAppendingString:@"s"];
        }
    }
}

@end
