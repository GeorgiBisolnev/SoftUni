function solve(array){
    let result = array.sort((a,b)=>a.localeCompare(b));
    let group = undefined;
    for (const item of array) {
        let product = item.split(' : ')[0];
        let price = item.split(' : ')[1];
        if(group==undefined){
            let group=product[0];
        } 
        if(group!=product[0]){
            group=product[0];
            console.log(group);
        }
        console.log(`  ${product}: ${price}`);
    }
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10'])