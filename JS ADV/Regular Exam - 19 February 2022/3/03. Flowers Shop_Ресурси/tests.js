const flowerShop = require("./flowerShop.js");
const expect = require("chai").expect;

describe("flowerShop", function() {
    describe("calcPriceOfFlowers", function() {
        it("Correct inputs", function() {
            expect(flowerShop.calcPriceOfFlowers('Roza',5,5)).to.be.equals('You need $25.00 to buy Roza!');
            expect(flowerShop.calcPriceOfFlowers('Roza',0,5)).to.be.equals('You need $0.00 to buy Roza!');
            expect(flowerShop.calcPriceOfFlowers('Roza',-5,5)).to.be.equals('You need $-25.00 to buy Roza!');

        });

        it("not correct inputs", function() {
            expect(()=>flowerShop.calcPriceOfFlowers('Roza',5.5,5)).to.throw(Error,'Invalid input!');
            expect(()=>flowerShop.calcPriceOfFlowers('Roza',5,5.5)).to.throw(Error,'Invalid input!');
            expect(()=>flowerShop.calcPriceOfFlowers({},5,5)).to.throw(Error,'Invalid input!');
            expect(()=>flowerShop.calcPriceOfFlowers(null,5,5)).to.throw(Error,'Invalid input!');
            expect(()=>flowerShop.calcPriceOfFlowers([],5,5)).to.throw(Error,'Invalid input!');
            expect(()=>flowerShop.calcPriceOfFlowers(undefined,5,5)).to.throw(Error,'Invalid input!');

            expect(()=>flowerShop.calcPriceOfFlowers('undefined',{},5)).to.throw(Error,'Invalid input!');
            expect(()=>flowerShop.calcPriceOfFlowers('undefined',[],5)).to.throw(Error,'Invalid input!');
            expect(()=>flowerShop.calcPriceOfFlowers('undefined',undefined,5)).to.throw(Error,'Invalid input!');
            expect(()=>flowerShop.calcPriceOfFlowers('undefined',null,5)).to.throw(Error,'Invalid input!');
            expect(()=>flowerShop.calcPriceOfFlowers('undefined','null',5)).to.throw(Error,'Invalid input!');

            expect(()=>flowerShop.calcPriceOfFlowers('undefined',5,{})).to.throw(Error,'Invalid input!');
            expect(()=>flowerShop.calcPriceOfFlowers('undefined',5,[])).to.throw(Error,'Invalid input!');
            expect(()=>flowerShop.calcPriceOfFlowers('undefined',5,undefined)).to.throw(Error,'Invalid input!');
            expect(()=>flowerShop.calcPriceOfFlowers('undefined',5,null)).to.throw(Error,'Invalid input!');
            expect(()=>flowerShop.calcPriceOfFlowers('undefined',5,'null')).to.throw(Error,'Invalid input!');
            

        });
     });
    
     describe("checkFlowersAvailable", function() {
         let arr=["Rose", "Lily", "Orchid"];
        it("Correct inputs", function() {
            expect(flowerShop.checkFlowersAvailable('Lily',arr)).to.be.equals('The Lily are available!')
            expect(flowerShop.checkFlowersAvailable('Rose',arr)).to.be.equals('The Rose are available!')
            expect(flowerShop.checkFlowersAvailable('Orchid',arr)).to.be.equals('The Orchid are available!')

        });

        it("not correct inputs", function() {
            expect(flowerShop.checkFlowersAvailable('Roza',arr)).to.be.equals('The Roza are sold! You need to purchase more!');
            expect(flowerShop.checkFlowersAvailable('Roza',[])).to.be.equals('The Roza are sold! You need to purchase more!');
            expect(flowerShop.checkFlowersAvailable('rose',arr)).to.be.equals('The rose are sold! You need to purchase more!');
        });
     });

     describe("sellFlowers", function() {
        let flowersArray=["Rose", "Lily", "Orchid"];
       it("Correct inputs", function() {
        expect(flowerShop.sellFlowers(flowersArray,0)).to.be.equals('Lily / Orchid');
        expect(flowerShop.sellFlowers(flowersArray,1)).to.be.equals('Rose / Orchid');
        expect(flowerShop.sellFlowers(flowersArray,2)).to.be.equals('Rose / Lily');
        expect(flowerShop.sellFlowers(["Rose", "Lily", "Orchid","Orhi"],2)).to.be.equals('Rose / Lily / Orhi');

       });

       it("not correct inputs", function() {
        expect(()=>flowerShop.sellFlowers(flowersArray,-1)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(flowersArray,3)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(flowersArray,3)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(flowersArray,'3')).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(flowersArray,null)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(flowersArray,[])).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(flowersArray,{})).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(flowersArray,undefined)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(flowersArray,3.1)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(flowersArray,false)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers('flowersArray',1)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(undefined,1)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(null,1)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers([],1)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers({},1)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(1,1)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(1.1,1)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(false,1)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(NaN,1)).to.throw(Error,'Invalid input!');
        expect(()=>flowerShop.sellFlowers(flowersArray,NaN)).to.throw(Error,'Invalid input!');
       });
    });
});