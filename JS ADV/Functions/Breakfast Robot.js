function solve (num){

    let sum = 0;

    function inner(number){
        sum+=number;

        return inner;
    }
    inner.toString = ()=>{
        return sum;
    }

    return inner(num);
}

console.log(solve(5)(3)(3).toString());