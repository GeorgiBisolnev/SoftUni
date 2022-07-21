const load = document.getElementById('btnLoad');
const phonebook = document.getElementById('phonebook');
const createButton = document.getElementById('btnCreate')

function attachEvents() {
    load.addEventListener('click',loadPhonebook)
    createButton.addEventListener('click', onClickCreate)
}
async function onClickCreate(){
    let person = document.getElementById('person').value;
    let phone = document.getElementById('phone').value;
    if (person && phone) {
        let res = await fetch('http://localhost:3030/jsonstore/phonebook', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                person,
                phone
            })
        })
    }
    document.getElementById('person').value=''
    document.getElementById('phone').value=''
}

async function loadPhonebook(){
    phonebook.innerHTML='';

    const res = await fetch('http://localhost:3030/jsonstore/phonebook');
    const data =Object.values( await res.json());

    for (let i = 0; i < data.length; i++) {
        let li = createElement('li',`${data[i].person}: ${data[i].phone}`,['id',data[i]._id])
        let deleteButton = createElement('button','Delete',['id','deleteButton'])
        deleteButton.addEventListener('click',deletePhoneFromPhonebook);
        li.appendChild(deleteButton)
        phonebook.appendChild(li);
    }
}

async function deletePhoneFromPhonebook(event){
    let idToDelete = event.target.parentElement.id;
    event.target.parentElement.remove();
    let res = await fetch(`http://localhost:3030/jsonstore/phonebook/${idToDelete}`,{
        method:'DELETE'
    })

}


function createElement(type,content='',atributes=[]){

    const element = document.createElement(type);

    element.textContent = content;

        for (let i = 0; i < atributes.length; i+=2) {
            element.setAttribute(atributes[i],atributes[i+1])
        }


    return element;
}
attachEvents();