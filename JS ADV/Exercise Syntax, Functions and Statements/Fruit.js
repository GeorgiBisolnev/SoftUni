function solve(name,mg,price){
    let kg=mg/1000;

    console.log('I need $'+ (kg*price).toFixed(2) + ' to buy '+ kg.toFixed(2) +' kilograms '+name+'.');

}

solve("Mango",2500,2);