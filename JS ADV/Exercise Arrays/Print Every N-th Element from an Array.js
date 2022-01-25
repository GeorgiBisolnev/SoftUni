function solve(arr,number){
    let resultArr = [];
    for(let i=0;i<arr.length;i=i+number){
        resultArr.push(arr[i]);
    }
    return resultArr;
}

solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2)