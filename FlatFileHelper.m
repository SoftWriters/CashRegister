//
//  FlatFileHelper.m
//  CashRegister
//
//  Created by  Robert Dohner on 12/14/16.
//  Copyright © 2016 SoftWriters. All rights reserved.
//

#import "FlatFileHelper.h"

@implementation FlatFileHelper

-(id)init {
    
    if (self = [super init]) {

    }
    return self;
}

// Inputs the data from the input file.
-(NSArray *)inputFromFile:(NSString *)fileString {

    NSError *error;
    NSString *fileContents = [NSString stringWithContentsOfFile:[[NSBundle mainBundle] pathForResource:fileString ofType:@"txt"] encoding:NSUTF8StringEncoding error:&error];
    
    if (!error) {
        
        NSArray *fileArray = [fileContents componentsSeparatedByString:@"\n\n"];
        return fileArray;
        
    } else {
        
        NSLog( @"error: %@", error.localizedDescription);
        return nil;
    }
}

// Outputs the data to an output file.  I have logged the location of the file so that you may look directly at the file.
-(void)outputToFile:(NSString *)fileString usingArray:(NSArray *)outputArray {
    
    NSArray *paths = NSSearchPathForDirectoriesInDomains( NSDocumentDirectory, NSUserDomainMask, YES);
    NSString *filePath = [[paths objectAtIndex:0]stringByAppendingPathComponent:fileString];
    NSString *dataString = @"";
    
    for (int i = 0; i < outputArray.count; i++) {
        
        dataString = [dataString stringByAppendingString:[outputArray objectAtIndex:i]];
        dataString = [dataString stringByAppendingString:@"\n\n"];
    }
    
    [dataString writeToFile:filePath atomically:YES encoding:NSUTF8StringEncoding error:nil];
    
    NSLog(@"%@",[[[NSFileManager defaultManager] URLsForDirectory:NSDocumentDirectory inDomains:NSUserDomainMask] lastObject]);
}


@end
