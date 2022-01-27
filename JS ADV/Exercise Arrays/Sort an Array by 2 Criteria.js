function solve(arr){
    let array = [];
    array=arr;
    array.sort(function(a,b){       
        if(a.length > b.length){return 1}
        if(a.length < b.length){return -1}
        if(a > b){return 1}
        if(a < b){return - 1}       
        return 0;
    });
    console.log(array.join('\n'));
}

solve(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George'])