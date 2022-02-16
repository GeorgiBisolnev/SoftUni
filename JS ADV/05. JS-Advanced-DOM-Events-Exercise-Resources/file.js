function solve(materials) {
    let result = JSON.parse(materials);
    for (const item of result) {
      console.log(item);
    }
  
  }
  
  
  solve([{"name": "Sofa", 
  "img": "https://res.cloudinary.com/maisonsdumonde/image/upload/q_auto,f_auto/w_200/img/grey-3-seater-sofa-bed-200-13-0-175521_9.jpg",
   "price": 150,
    "decFactor": 1.2}])