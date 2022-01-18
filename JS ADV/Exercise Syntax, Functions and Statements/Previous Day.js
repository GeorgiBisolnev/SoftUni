function pDay(y,m,d){
    let current = new Date(y, m-1, d);
    console.log(current);
    current.setDate(current.getDate()-1);

    console.log(`${current.getFullYear()}-${current.getMonth()+1}-${current.getDate()}`)
}

pDay(2016,9,30);
pDay(2016,10,1);
