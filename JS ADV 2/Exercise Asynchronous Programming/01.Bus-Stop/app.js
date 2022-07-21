async function getInfo() {


    let stopname = document.getElementById('stopName');
    let timetableelement = document.getElementById('buses');

    const id= document.getElementById('stopId').value;    
    const url = `http://localhost:3030/jsonstore/bus/businfo/${id}`;
    try{

        stopname.textContent='';
        timetableelement.textContent='';
        const res = await fetch(url);
    
        const data = await res.json();
    
        console.log(data);
    
        stopname.textContent=data.name;

        for(const[key, value] of Object.entries(data.buses)){
            let currentLi = document.createElement('li');
            currentLi.textContent=`Bus ${key} arrives in ${value} minutes`;
            timetableelement.appendChild(currentLi);
        }
    
        }catch(err){
            stopname.textContent="Error ...";
        }


}