function solve(a,b){
    let min=a;
    if(b<a){
        min=b;
    }
    for(let i=min;i>0;i--){
        if(a%i==0 && b%i==0){
            return i;
        }
    }
}