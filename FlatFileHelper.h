//
//  FlatFileHelper.h
//  CashRegister
//
//  Created by  Robert Dohner on 12/14/16.
//  Copyright © 2016 SoftWriters. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface FlatFileHelper : NSObject

-(NSArray *)inputFromFile:(NSString *)fileString;

-(void)outputToFile:(NSString *)fileString usingArray:(NSArray *)outputArray;

@end
