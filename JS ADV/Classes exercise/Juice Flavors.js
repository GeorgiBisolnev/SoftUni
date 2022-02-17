function solve(input){
    let map= new Map();
    let setorder = new Set();

    for (const line of input) {
        let [juice,number] = line.split(' => ');
        if(!map.has(juice)){

            if(Number(number)>=1000){
                setorder.add(juice);
            }

            map.set(juice,Number(number));
        } else{
            let curQuantity = map.get(juice);            
            map.set(juice,Number(map.get(juice))+Number(number))
            
            if(Number(curQuantity)+Number(number)>=1000){
                setorder.add(juice);
            }
        }        
    }
    //print
    for (const item of setorder) {
        if(map.get(item)/1000>=1){
            console.log(`${item} => ${Math.floor(map.get(item)/1000)}`);
        }
    }
}

solve(['Kiwi => 234','Pear => 2345','Watermelon => 3456','Kiwi => 4567','Pear => 5678','Watermelon => 6789'])