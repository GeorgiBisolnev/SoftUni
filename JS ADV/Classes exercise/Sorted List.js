class List{

    constructor(){
        this.numbers=[];
        this.size=0;
    }

    add(number){
        this.numbers.push(number);
        this.size++;
    }
    remove(index){
        if(index>=0 && index<this.numbers.length){
            this.numbers.splice(index,1);
            this.size--;
        }
    }
    get(index){
        if(index>=0 && index<this.numbers.length){
            this.numbers.sort((a,b)=>a-b);
            return this.numbers[index]
        }
    }
    size(){
        return this.size;
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));