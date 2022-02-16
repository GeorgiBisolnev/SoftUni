function solve(){

    
    let arr = [];

    for (const argument of arguments) {
        let obj = {};
        obj['type']=typeof(argument);
        obj['value']=argument;
        arr.push(obj);
        
    }
    let obj={};
    for (const item of arr) {
        console.log(`${item['type']}: ${item['value']}`);
        
        if(obj[item['type']]){
            obj[item['type']]++;
        }else{
            obj[item['type']]=1;
        }
    }

    for (const [prop, value] of Object.entries(obj).sort((a,b) => b[1] - a[1])){
        console.log(`${prop} = ${value}`);
    }

}

solve('cat',22, 42, function () { console.log('Hello world!'); });