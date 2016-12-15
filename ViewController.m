//
//  ViewController.m
//  CashRegister
//
//  Created by  Robert Dohner on 12/14/16.
//  Copyright © 2016 SoftWriters. All rights reserved.
//

#import "ViewController.h"
#import "FlatFileHelper.h"
#import "ChangeCalculator.h"

@interface ViewController ()

@end

@implementation ViewController

NSString *const kInputString = @"input";
NSString *const kOutputString = @"output";

- (void)viewDidLoad {
    
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
    
    FlatFileHelper *helper = [[FlatFileHelper alloc] init];
    ChangeCalculator *calculator = [[ChangeCalculator alloc] init];
    NSString *textViewString = @"";
    
    outputArray = [[NSMutableArray alloc] init];
    
    inputArray = [helper inputFromFile:kInputString];
    for (int i = 0; i < inputArray.count; i++) {
        
        [outputArray addObject:[calculator calculateChange:[inputArray objectAtIndex:i]]];
        textViewString = [textViewString stringByAppendingString:[outputArray objectAtIndex:i]];
        textViewString = [textViewString stringByAppendingString:@"\n\n"];
        
    }
    
    outputTextView.text = textViewString;
    
    [helper outputToFile:kOutputString usingArray:outputArray];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
