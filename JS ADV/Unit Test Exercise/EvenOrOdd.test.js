const {expect} = require('chai');
const isOddOrEven = require('./EvenOrOdd');

describe('Zadacha 2',()=>{
    it('Must work fine',()=>{

        expect(isOddOrEven('22')).to.equal('even');
        expect(isOddOrEven('')).to.equal('even');
        expect(isOddOrEven('1""""""""""""""""""""""""""""""""""""""')).to.equal('odd');


    })
    it('Must work test with no strin input',()=>{

        expect(isOddOrEven(1)).to.equal(undefined);
        expect(isOddOrEven([])).to.equal(undefined);
        expect(isOddOrEven(null)).to.equal(undefined);
        expect(isOddOrEven({})).to.equal(undefined);
        expect(isOddOrEven(-2222)).to.equal(undefined);
        expect(isOddOrEven(1.2)).to.equal(undefined);


    })
})