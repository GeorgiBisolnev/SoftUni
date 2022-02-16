function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let input = JSON.parse(document.querySelector('#inputs textarea').value);
      
      let resturants=[];

      for (const resturant of input) {
         let arguments = resturant.split(' - ');
         let name = arguments[0];
         let workers = arguments[1].split(', ');
         let currentResturent = {};
         currentResturent['Name'] = name;
         currentResturent['Workers'] = [];
         currentResturent['AverageSalary'] = function () {
            if(this.Workers.length>0){
               this.Workers.reduce((a,b)=>a+b.Salary)/this.Workers.length;
            } else{
               return 0
            }
         }
         currentResturent['BestSalary'] = function () {
            if(this.Workers.length!=0){
               let bestWorker=this.Workers[0].Salary;
               for (const worker of this.Workers) {
                  if(worker.Salary>bestWorker){
                     bestWorker=worker.Salary;
                  }
               }
               return bestWorker;
            }else{
               return 0
            }
         }

         for (const worker of workers) {
            let arguments = worker.split(' ');
            let workerName = arguments[0];
            let workerSalary = arguments[1];
            let currentWorker={
               Name: workerName,
               Salary: workerSalary,
               toString(){
                  return `Name: ${this.Name} With Salary: ${this.Salary}`;
               }
            };
         currentResturent.Workers.push(currentWorker);
         }

         if(restaurants.some(x => x.Name === restaurantName)){
            let rest = restaurants.find(x => x.Name === restaurantName);
            rest.Workers = rest.Workers.concat(currentRestaurant.Workers);
         }else{
            restaurants.push(currentRestaurant);
         }

       

      }
      restaurants.sort((a,b) => b.AverageSalary() - a.AverageSalary());
      restaurants[0].Workers.sort((a,b) => b.Salary - a.Salary);
      document.getElementById('bestRestaurant').querySelector('p').textContent = `Name: ${restaurants[0].Name} Average Salary: ${restaurants[0].AverageSalary().toFixed(2)} Best Salary: ${restaurants[0].BestSalary().toFixed(2)}`;
      document.getElementById('workers').querySelector('p').textContent = restaurants[0].Workers.map(x => x.toString()).join(' ');


   }
}