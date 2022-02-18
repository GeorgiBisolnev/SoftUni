const library = require("./library.js");
const expect = require("chai").expect;

describe("library", function() {

    describe("calcPriceOfBook", function() {
        it("Correct inputs", function() {
            expect(library.calcPriceOfBook('It',2021)).to.be.equals('Price of It is 20.00');
            expect(library.calcPriceOfBook('It1',2006)).to.be.equals('Price of It1 is 20.00');
            expect(library.calcPriceOfBook('It2',1855)).to.be.equals('Price of It2 is 10.00');
            expect(library.calcPriceOfBook('It3',1980)).to.be.equals('Price of It3 is 10.00');
        });
        it("invalid inputs", function() {
            expect(()=>library.calcPriceOfBook(200,2006)).to.throw(Error,'Invalid input');
            expect(()=>library.calcPriceOfBook('It','200hg6')).to.throw(Error,'Invalid input');
            expect(()=>library.calcPriceOfBook(null,'200hg6')).to.throw(Error,'Invalid input');
            expect(()=>library.calcPriceOfBook(undefined,'200hg6')).to.throw(Error,'Invalid input');
            expect(()=>library.calcPriceOfBook({},'200hg6')).to.throw(Error,'Invalid input');
            expect(()=>library.calcPriceOfBook(['It'],'200hg6')).to.throw(Error,'Invalid input');
        });
     });

     describe("find books", function() {
        it("Currect inputs", function() {
            let booksArray=["Troy", "Life Style", "Torronto", 'It'];
            expect(library.findBook(booksArray,'It')).to.be.equals('We found the book you want.');
            expect(library.findBook(booksArray,'It1')).to.be.equals('The book you are looking for is not here!');        
        });
        it("invalid inputs", function() {
            expect(() => library.findBook([], "Paf")).to.throw(Error, "No books currently available");
        });
     });

     describe("arrangeTheBooks", function() {
        it("Currect inputs", function() {
            expect(library.arrangeTheBooks(0)).to.be.equals('Great job, the books are arranged.');
            expect(library.arrangeTheBooks(10)).to.be.equals('Great job, the books are arranged.');
            expect(library.arrangeTheBooks(40)).to.be.equals('Great job, the books are arranged.');
            expect(library.arrangeTheBooks(41)).to.be.equals('Insufficient space, more shelves need to be purchased.');
            expect(library.arrangeTheBooks(50)).to.be.equals('Insufficient space, more shelves need to be purchased.');
            expect(library.arrangeTheBooks(100)).to.be.equals('Insufficient space, more shelves need to be purchased.');

        });
        it("invalid inputs", function() {
            expect(()=>library.arrangeTheBooks(-1)).to.throw(Error,'Invalid input');
            expect(()=>library.arrangeTheBooks(null)).to.throw(Error,'Invalid input');
            expect(()=>library.arrangeTheBooks(undefined)).to.throw(Error,'Invalid input');
            expect(()=>library.arrangeTheBooks({})).to.throw(Error,'Invalid input');
            expect(()=>library.arrangeTheBooks([])).to.throw(Error,'Invalid input');

        });
     });
     // TODO: …
});