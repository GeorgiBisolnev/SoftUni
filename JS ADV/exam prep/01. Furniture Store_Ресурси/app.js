window.addEventListener('load', solve);

function solve() {
    let modelElement = document.getElementById('model');
    let yearElement = document.getElementById('year');
    let descriptionElement = document.getElementById('description');
    let priceElement = document.getElementById('price');
    let addButtonElement = document.getElementById('add');
    let bodyTable = document.getElementById('furniture-list');

    document.getElementById("add").addEventListener("click", function(event){
        event.preventDefault()
      });

    addButtonElement.addEventListener('click', ()=> {

        


        if (modelElement.value != '' && descriptionElement != '' && Number(yearElement.value) > 0 && Number(priceElement.value) > 0) {
            
            let totalelement = document.querySelector('.total-price');
            let price = Number(priceElement.value);
            let total = Number(totalelement.textContent);
            let newTrInfo = document.createElement('tr');            
            let newtdmodel = document.createElement('td');
            let newtdprice = document.createElement('td');
            let newtdbuttons = document.createElement('td');
            let newMoreInfoButt = document.createElement('button');
            let newBuyItButt = document.createElement('button');

            newtdmodel.textContent=modelElement.value;
            newtdprice.textContent = Number(priceElement.value).toFixed(2);
            newTrInfo.appendChild(newtdmodel); newTrInfo.appendChild(newtdprice);
            newMoreInfoButt.textContent='More info';
            newMoreInfoButt.className='moreBtn'


            newBuyItButt.textContent='Buy it';


            newBuyItButt.className='buyBtn'
            newtdbuttons.appendChild(newMoreInfoButt);
            newtdbuttons.appendChild(newBuyItButt);
            newTrInfo.appendChild(newtdbuttons);
            newTrInfo.className='info';
            

            //hide tr
            let newTrHide = document.createElement('tr');
            newTrHide.className='hide';
            let newtdyear = document.createElement('td');
            newtdyear.textContent='Year: ' + Number(yearElement.value);
            let newtddescription = document.createElement('td');
            newtddescription.textContent = 'Description: '+descriptionElement.value;
            newtddescription.setAttribute('colspan', 3);
            newTrHide.appendChild(newtdyear);
            newTrHide.appendChild(newtddescription);

            newMoreInfoButt.addEventListener('click', ()=>{
                if(newMoreInfoButt.textContent=='More info'){
                    newTrHide.style.display='contents';
                    newMoreInfoButt.textContent='Less info'
                } else{
                    newTrHide.style.display='none';
                    newMoreInfoButt.textContent='More info'
                }
                
            }); 

            newBuyItButt.addEventListener('click', ()=>{
                
                totalelement.textContent=(price+total).toFixed(2);
                newTrInfo.remove();
                newTrHide.remove();
                alert('asd')

            })

            bodyTable.appendChild(newTrInfo);
            bodyTable.appendChild(newTrHide);

            modelElement.value='';
            descriptionElement.value='';
            yearElement.value='';
            priceElement.value='';
        }
    
    })


    
}
