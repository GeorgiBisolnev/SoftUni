function solve(arr,order){
    if(order=='asc'){
        arr.sort((a,b)=>a-b);
    } else {
        arr.sort((a,b)=>b-a);
    }

    return arr;
}