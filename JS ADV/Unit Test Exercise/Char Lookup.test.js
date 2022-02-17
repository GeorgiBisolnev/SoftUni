const {expect} = require('chai');
const lookupChar = require('./Char Lookup');

describe('Zadacha 3',()=>{
    it('check for correct parameters',()=>{

        expect(undefined).to.be.equal(lookupChar(22,1))
        expect(undefined).to.be.equal(lookupChar(null,1))
        expect(undefined).to.be.equal(lookupChar({},1))
        expect(undefined).to.be.equal(lookupChar([],1))
        expect(undefined).to.be.equal(lookupChar(undefined,1))
        expect(undefined).to.be.equal(lookupChar(NaN,1))
        expect(undefined).to.be.equal(lookupChar(NaN,1))

        expect(undefined).to.be.equal(lookupChar('String',{}))
        expect(undefined).to.be.equal(lookupChar('String',[]))
        expect(undefined).to.be.equal(lookupChar('String',null))
        expect(undefined).to.be.equal(lookupChar('String',undefined))
        expect(undefined).to.be.equal(lookupChar('String','2'))
        expect(undefined).to.be.equal(lookupChar('String',NaN))
        expect(undefined).to.be.equal(lookupChar('String',2.2))

        expect('Incorrect index').to.be.equal(lookupChar("12345",5))
        expect('Incorrect index').to.be.equal(lookupChar("12345",-1))

    })
    it('Must work fine',()=>{
        expect('1').to.be.equal(lookupChar("12345",0))
        expect('5').to.be.equal(lookupChar("12345",4))
        expect(' ').to.be.equal(lookupChar("12345 2",5))
    })
})