const {expect} = require('chai');
const mathEnforcer = require('./Math Enforcer');

describe('Zadacha 4',()=>{
    it('Add 5 test',()=>{

        let f=mathEnforcer;
        expect(f.addFive(5)).to.be.equals(10);
        expect(f.addFive(-5)).to.be.equals(0);
        expect(f.addFive(5.5)).to.be.equals(10.5);
        expect(f.addFive(20.111)).to.be.closeTo(20.1,20.2);

        expect(f.addFive('5')).to.be.undefined;
        expect(f.addFive(undefined)).to.be.undefined;
        expect(f.addFive({})).to.be.undefined;
        expect(f.addFive(['5'])).to.be.undefined;
        expect(f.addFive(null)).to.be.undefined;
    })
    it('Sub 10 test',()=>{

        let f=mathEnforcer;
        expect(f.subtractTen(5)).to.be.equals(-5);
        expect(f.subtractTen(-5)).to.be.equals(-15);
        expect(f.subtractTen(5.55)).to.be.equals(-4.45);
        expect(f.subtractTen(10.555555)).to.be.closeTo(0.55,0.56);

        expect(f.subtractTen('5')).to.be.equals(undefined);
        expect(f.subtractTen(undefined)).to.be.equals(undefined);
        expect(f.subtractTen({})).to.be.equals(undefined);
        expect(f.subtractTen(['5'])).to.be.equals(undefined);
        expect(f.subtractTen(null)).to.be.equals(undefined);
    })

    it('sum 2 numbers test',()=>{

        let f=mathEnforcer;
        expect(f.sum(5,5)).to.be.equals(10);
        expect(f.sum(-5,10)).to.be.equals(5);
        expect(f.sum(5.5,1.55)).to.be.equals(7.05);
        expect(f.sum(1,1.111111)).to.be.closeTo(2.10,2.12);

        expect(f.sum('5',1)).to.be.equals(undefined);
        expect(f.sum(undefined,1)).to.be.equals(undefined);
        expect(f.sum({},1)).to.be.equals(undefined);
        expect(f.sum(['5'],1)).to.be.equals(undefined);
        expect(f.sum(null,1)).to.be.equals(undefined);

        expect(f.sum(1,'5')).to.be.equals(undefined);
        expect(f.sum(1,undefined)).to.be.equals(undefined);
        expect(f.sum(1,{})).to.be.equals(undefined);
        expect(f.sum(1,['5'])).to.be.equals(undefined);
        expect(f.sum(1,null)).to.be.equals(undefined);
    })
})