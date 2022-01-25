function solve(arr){
    let max=arr[0];
    let resArr=[];
    for (const num of arr) {
        if(max<=num){
            resArr.push(num)
            max=num;
        }
    }

    return resArr;
}

solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24])