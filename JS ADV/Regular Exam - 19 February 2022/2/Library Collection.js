class LibraryCollection{
    constructor(capacity){
        this.capacity=capacity;
        this.books=[];
    }

    addBook(bookName, bookAuthor){

        let newBook ={
            bookName:bookName,
            bookAuthor:bookAuthor,
            payed:false,
        }

        if(this.books.length>=this.capacity){
            throw new Error('Not enough space in the collection.');
        }

        this.books.push(newBook);

        return `The ${bookName}, with an author ${bookAuthor}, collect.`
    }
    payBook( bookName ){
        let isFound = this.books.find(book=>book.bookName==bookName);

        if(isFound==undefined){
            throw new Error(`${bookName} is not in the collection.`);
        } else if(isFound.payed==true){
            throw new Error(`${bookName} has already been paid.`);
        } else{
            for (const book of this.books) {
                if(book.bookName==bookName){
                    book.payed=true;
                    return `${bookName} has been successfully paid.`;
                }
            }
        }
    }
    removeBook(bookName){
        let isFound = this.books.find(book=>book.bookName==bookName);

        if(isFound==undefined){
            throw new Error(`The book, you're looking for, is not found.`);
        } else if(isFound.payed==false){
            throw new Error(`${bookName} need to be paid before removing from the collection.`)
        } else{

            for(let i=0;i<this.books.length;i++){
                if(this.books[i].bookName==bookName){
                    this.books.splice(i,1);
                    return `${bookName} remove from the collection.`
                }
            }
            
        }
    }
    getStatistics(bookAuthor){
        let result='';

        let isFound = this.books.find(book => book.bookAuthor==bookAuthor);
        if(typeof bookAuthor==="undefined"){
            result+=`The book collection has ${ this.capacity-this.books.length } empty spots left.\n`;
            let sorted = this.books.sort((a,b)=> a.bookName.localeCompare(b.bookName));
            for (const book of sorted) {
                let paid ='';
                if(book.payed==true){
                    paid='Has Paid';
                }else{
                    paid='Not Paid';
                }
                result+=`${book.bookName} == ${book.bookAuthor} - ${paid}.\n`;
            }
            return result.trim();
        } else if(isFound==undefined){
            throw new Error(`${bookAuthor} is not in the collection.`)
        } else{
            for (const book of this.books) {

                if(book.bookAuthor==isFound.bookAuthor){
                    let paid ='';
                if(book.payed==true){
                    paid='Has Paid';
                }else{
                    paid='Not Paid';
                }
                result+=`${book.bookName} == ${book.bookAuthor} - ${paid}.\n`;
                }
            }
            return result.trimEnd();
        }

        
    }
}

let biblioteka = new LibraryCollection(3);

console.log(biblioteka.addBook('Harry','JKR'));
console.log(biblioteka.addBook('Harry1','JKR'));
console.log(biblioteka.addBook('Harry12222','JKR1'));
console.log(biblioteka.payBook('Harry1'));
//console.log(biblioteka.removeBook('Harry1','JKR'));
console.log(biblioteka.getStatistics('JKR1'));

