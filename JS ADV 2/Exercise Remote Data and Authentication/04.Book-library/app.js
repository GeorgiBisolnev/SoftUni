const tableBody = document.querySelector('table tbody');
const baseurl = 'http://localhost:3030/jsonstore/collections/books'
const loadBooksButton=document.getElementById('loadBooks');
const form = document.querySelector('form');
const submitButton = document.querySelector('form button');
let titleInputElement = form.querySelector('[name="title"');
let authorInputElement = form.querySelector('[name="author"]');
let h3Element = form.querySelector("h3");

function solve(){
    tableBody.innerHTML='';
    loadBooksButton.addEventListener('click',loadBooks);
    form.addEventListener('submit', createEditBook);
        
}
async function createEditBook(e){

    e.preventDefault();
    let formdata = new FormData(form);
    let titleName = formdata.get('title');
    let authorName = formdata.get('author');

    if(submitButton.textContent=='Submit'){
        

        await fetch(baseurl,{
            method:'POST',
            headers:{
                'Content-Type': 'application\json'
            },
            body:JSON.stringify({
                title:titleName,
                author:authorName
            })
        });
        
        loadBooks();
    } else{
        submitButton.textContent='Submit'
        h3Element.textContent='FORM'
        await fetch(`${baseurl}/${sessionStorage.bookEdit}`,{
            method:'PUT',
            headers:{
                'Content-Type': 'application\json'
            },
            body:JSON.stringify({
                title:titleName,
                author:authorName
            })
        });

        loadBooks();
    }
    form.reset();
    
}

async function loadBooks(){
    let res = await fetch(baseurl);
    let data = await res.json();
    tableBody.innerHTML=''

    for (const [key, value] of Object.entries(data)) {
        let row = createElement('tr');
        let cell1 = createElement('td',value.title);
        let cell2 = createElement('td',value.author)
        let cell3 = createElement('td');
        let editButton = createElement('button',"Edit",['id',key]);
        editButton.addEventListener('click',()=>{
            sessionStorage.setItem('bookEdit',key);
            submitButton.textContent='Edit';
            titleInputElement.value = value.title;
            authorInputElement.value=value.author;
            h3Element.textContent='EditFORM'
        })
        let deleteButton = createElement('button','Delete',['id',key]);
        deleteButton.addEventListener('click', async ()=>{
            row.remove();

            await fetch(`http://localhost:3030/jsonstore/collections/books/${key}`,{
                method:'DELETE'
            })
        })

        cell3.appendChild(editButton);
        cell3.appendChild(deleteButton)

        row.appendChild(cell1);row.appendChild(cell2);row.appendChild(cell3);
        tableBody.appendChild(row);

    }
}


function createElement(type,content='',atributes=[]){

    const element = document.createElement(type);

    element.textContent = content;

        for (let i = 0; i < atributes.length; i+=2) {
            element.setAttribute(atributes[i],atributes[i+1])
        }


    return element;
}

solve();