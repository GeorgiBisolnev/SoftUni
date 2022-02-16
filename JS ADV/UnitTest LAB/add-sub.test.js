const createCalculator=require('./add-sub');
const {assert} = require('chai');

describe('zadacha 7',()=>{
    it('shuld work ok',()=>{

        let f=createCalculator();
        f.add(5);
        assert.equal(5,f.get())
        f.add(5);
        assert.equal(10,f.get())
        f.subtract(5);
        assert.equal(5,f.get())
        f.subtract(-5);
        assert.equal(10,f.get())
        f.subtract(11);
        assert.equal(-1,f.get())
    })
    
    it('shuld not work ok if input data is not a number',()=>{

        let f=createCalculator();
        f.add('asd');
        assert.equal(true,Number.isNaN(f.get()))
        f.subtract('asd');
        assert.equal(true,Number.isNaN(f.get()))
        f.add({});
        assert.equal(true,Number.isNaN(f.get()))
        f.subtract('asd');
        assert.equal(true,Number.isNaN(f.get()))
        f.add(null);
        assert.equal(true,Number.isNaN(f.get()))
        f.subtract(null);
        assert.equal(true,Number.isNaN(f.get()))
        f.add([]);
        assert.equal(true,Number.isNaN(f.get()))

    })
})