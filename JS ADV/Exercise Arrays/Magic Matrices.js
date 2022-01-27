function solve(array){

    let sumOfRow = array[0].reduce((a,b)=>a+b);

    for(let i=0;i<array.length;i++){
        let rowSum = array[i].reduce((a,b)=>a+b);
        let curCol=0;
        for(let j=0;j<array.length;j++){

            curCol+=array[j][i];
        }
        if(sumOfRow!=rowSum || sumOfRow!=curCol){
            return false;
        }
    }
return true;
}

console.log(
solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]));