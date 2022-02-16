const sum= require('./Sub Sum.js');
const {assert} = require('chai');

describe('Test zadacha 4', ()=>{
    it('Should return sum',()=>{
        let inputArr=[1,2,3,4,5];
        let resultToTest=sum(inputArr);

        assert.equal(resultToTest,15)        
    })
    it('Should return sum with string numbers',()=>{
        let inputArr=[1,2,3,4,'5'];
        let resultToTest=sum(inputArr);

        assert.equal(resultToTest,15)        
    })
    it('Should return sum with negative numbers',()=>{
        let inputArr=[1,2,3,4,-5];
        let resultToTest=sum(inputArr);

        assert.equal(resultToTest,5)        
    })
})

