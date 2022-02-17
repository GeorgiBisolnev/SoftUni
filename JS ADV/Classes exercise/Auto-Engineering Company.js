function solve(input){
    let brands=new Map();
    for (const line of input) {
        let [carBrand,carModel,producedCars] = line.split(' | ');
        producedCars=Number(producedCars);
        if(!brands.has(carBrand)){
            let car={};
            car[carModel]=producedCars;
            brands.set(carBrand,car)
        } else{
            let currcar=brands.get(carBrand);
            if(currcar.hasOwnProperty(carModel)){
                currcar[carModel]+=producedCars;
            } else{
                
                currcar[carModel]=producedCars;
            }
        }
    }



    for (let [key,value] of brands) {
        console.log(key);
        for (const [model,numbers] of Object.entries(value)) {
            console.log(`###${model} -> ${numbers}`)
        }
    }
}

solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10'])