//
//  ChangeCalculator.h
//  CashRegister
//
//  Created by  Robert Dohner on 12/14/16.
//  Copyright © 2016 SoftWriters. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface ChangeCalculator : NSObject {
    
    int amountOwed;
    int amountGiven;
    NSArray *coinValueArray;           // The values of all the coins
    NSArray *coinNameArray;            // The names of all the coins
    NSMutableArray *changeArray;       // The change that will be returned
}

-(NSString *)calculateChange:(NSString *)inputString;

@end
