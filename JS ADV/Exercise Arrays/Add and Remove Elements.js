function solve(arr){
    let count=0;
    let resultArr=[];
    for (const command of arr) {
        count++;
        if  (command=='add'){
            resultArr.push(count);
        }else{
            resultArr.pop();
        }
    }
    if(resultArr.length<1){
        console.log('Empty');
    }
    else{

        for (const num of resultArr) {
            console.log(num);
        }
    }
}

solve(['add', 
'add', 
'add', 
'add'])
solve(['remove', 
'remove', 
'remove'])
solve(['add', 
'add', 
'remove', 
'add', 
'add'])