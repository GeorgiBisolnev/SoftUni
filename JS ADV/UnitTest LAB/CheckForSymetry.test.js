const isSymmetric = require('./CheckForSymetry.js');
const {assert} = require('chai');

describe('zadacha 5',()=>{

    it("Should work ",()=>{

        assert.equal(isSymmetric([1,2,3,3,2,1]),true)
        arr=[1,2,1];
        assert.equal(isSymmetric(arr),true)
        arr=[false,2,false];
        assert.equal(isSymmetric(arr),true)
    })

    it("Should work if not an array ",()=>{

        let notAnArry={};
        assert.equal(isSymmetric(notAnArry),false)
         notAnArry=1;
        assert.equal(isSymmetric(notAnArry),false)
         notAnArry='asd';
        assert.equal(isSymmetric(notAnArry),false)
        notAnArry=null;
        assert.equal(isSymmetric(notAnArry),false)
        notAnArry=undefined;
        assert.equal(isSymmetric(notAnArry),false)


    })
    it("Should work not work if not symetric",()=>{

        let arr=[1,2,3,3,2,2];

        assert.equal(isSymmetric(arr),false)

    })
    it("Should work if there is mix type of symbols",()=>{

        let arr=[1.1,2,'asd','asd',2,1.1];

        assert.equal(isSymmetric(arr),true)
        arr=[1.1,'2','asd','asd',2,1.1];

        assert.equal(isSymmetric(arr),false)
    })
    it("Should work not if it is one symbol array",()=>{

        let arr=[1];

        assert.equal(isSymmetric(arr),true)
    })
    it("Should work if emty array",()=>{

        let arr=[];

        assert.equal(isSymmetric(arr),true)
    })
})