class Stringer{
    constructor(word,number){
        this.innerString=word;
        this.innerLength=Number(number);
    }

    decrease(num){
        this.innerLength-=Number(num);
        if(this.innerLength<0){
            this.innerLength=0;
        }
    }
    increase(num){
        this.innerLength+=Number(num);
    }

    toString(){
        let result=this.innerString.substring(0,this.innerLength);
        if(this.innerLength<this.innerString.length){
            result+='...';
        }

        return result;        
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test