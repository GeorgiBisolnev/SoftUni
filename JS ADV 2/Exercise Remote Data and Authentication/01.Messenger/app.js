const url = 'http://localhost:3030/jsonstore/messenger'
const messageBox = document.getElementById('messages');
const refreshButton = document.getElementById('refresh');
const sendButton = document.getElementById('submit');
const inputsArray = document.querySelectorAll('#controls input');
const authorText = document.getElementById('author')
const contentText= document.getElementById('content');

function attachEvents() {
    refreshButton.addEventListener('click', loadMessages);
    sendButton.addEventListener('click',sendMessage);    
    
}

function sendMessage(){
    let inputs = Object.values(inputsArray)
    let message={
        author: inputs[0].value,
        content: inputs[1].value,
    }
    request(url,message);
}

async function loadMessages(){
    let res = await fetch(url);
    let data = Object.values(await res.json());

    console.log(data);
    messageBox.textContent=data.map(({author,content}) => `${author}: ${content}`).join('\n')
}

async function request(url, option){

    if(option){
        send = {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(option)
          };
          console.log((send));
    }
    let res = await fetch(url,send);
    console.log(res);
}

attachEvents();