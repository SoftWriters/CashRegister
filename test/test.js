const { assert } = require('chai');
const fs = require('fs');
const app = require('../src/CashRegister');

describe('Test Getting Amount Due', () => {
  it('Good Math, Getting correct change', (done) => {
    app.getAmountOwed('1.00,2.00')
      .then((amount) => {
        assert.equal(amount, '1.00', 'The amount owed should be 1.00');
        done();
      })
      .catch(() => {
        assert.fail('Failed');
        done();
      });
  });

  it('Catch, Not enough money', (done) => {
    app.getAmountOwed('2.00,1.00')
      .then((amount) => {
        assert.fail('Should not be able to calculate change');
        done();
      })
      .catch((response) => {
        assert.equal(response, 'Not Enough Money');
        done();
      });
  });
});

describe('Test Getting Correct Change', () => {
  it('Getting correct change for 3.33', (done) => {
    app.getCorrectChange('3.33')
      .then((map) => {
        assert.equal(map.get(1), 3, 'Change should contain three dollars');
        assert.equal(map.get(0.25), 1, 'Change should contain one quarter');
        assert.equal(map.get(0.05), 1, 'Change should contain one nickel');
        assert.equal(map.get(0.01), 3, 'Change should contain three pennies');
        done();
      });
  });

  it('Getting correct change for 15.88', (done) => {
    app.getCorrectChange('15.88')
      .then((map) => {
        assert.equal(map.get(10), 1, 'Change should contain one ten');
        assert.equal(map.get(5), 1, 'Change should contain one five');
        assert.equal(map.get(0.25), 3, 'Change should contain three quarters');
        assert.equal(map.get(0.10), 1, 'Change should contain one dime');
        assert.equal(map.get(0.01), 3, 'Change should contain three pennies');
        done();
      });
  });

  it('Getting correct change for 1.51', (done) => {
    app.getCorrectChange('1.51')
      .then((map) => {
        assert.equal(map.get(1), 1, 'Change should contain one dollar');
        assert.equal(map.get(0.25), 2, 'Change should contain two quarters');
        assert.equal(map.get(0.01), 1, 'Change should contain one penny');
        done();
      });
  });

  it('Testing for correct random change for 18', (done) => {
    app.getCorrectChange('18')
      .then((map) => {
        let total = 0;
        map.forEach((value, key) => {
          total += value * key;
        });

        assert.equal(total, 18, 'Change should total to 18 dollars');
        done();
      });
  });
});

describe('Testing Randomizing Array', () => {
  it('Testing randomization', (done) => {
    const array = [1, 2, 3, 4, 5, 6, 7, 8, 9];

    const randomArray = app.randomizeArray(array);

    assert.notEqual(randomArray[0], 1, 'Random Array cannot have same start parameter');
    done();
  });
});

describe('Testing full process', () => {
  it('Testing the full program', (done) => {
    const inputString = '2.12,3.00\n1.97,2.00\n3.33,5.00\n5.55,20.00\n4.00,2.00';
    fs.writeFileSync('./src/input.txt', inputString);
    require('../src/CashRegister');
    const outputString = fs.readFileSync('./src/output.txt', 'utf-8');

    assert.equal(outputString, '3 Quarters, 1 Dime, 3 Pennies\n3 Pennies\n1 Dollar, 2 Quarters, 1 Dime, 1 Nickel, 2 Pennies\n1 Ten, 4 Dollars, 1 Quarter, 2 Dimes\nNot Enough Money');
    done();
  });
});
