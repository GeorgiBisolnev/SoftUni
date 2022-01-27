function solve(arr){
    for(let i=0;i<arr.length;i++){
        if(i%2==0){
            let min=arr[i];
            let delIndex=i;
            for(let j=i;j<arr.length;j++){
                if(arr[j]<min){
                    min=arr[j];
                    delIndex=j;
                }
            }
            arr.splice(delIndex,1);
            arr.splice(i,0,min);
        }else{
            let max=arr[i];
            let delIndex=i;
            for(let j=i;j<arr.length;j++){
                if(arr[j]>max){
                    max=arr[j];
                    delIndex=j;
                }
            }
            arr.splice(delIndex,1);
            arr.splice(i,0,max);
        }
    }

    return arr;
    console.log(arr.join(' '));
};

solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56])