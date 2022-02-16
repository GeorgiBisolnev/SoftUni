function solve(array){
    let result=[];
    for(index=1;index<array.length;index++){
        let [Town,Latitude,Longitude] = array[index].split('|').filter((x)=>x.length>1);
        let str = array[index].split('|').filter((x)=>x);
        let obj={};
        obj['Town'] = Town.trim();
        obj['Latitude'] = Number(Number(Latitude).toFixed(2));
        obj['Longitude'] = Number(Number(Longitude).toFixed(2));
        result.push(obj);
    }
    return JSON.stringify(result);
}

solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |'])