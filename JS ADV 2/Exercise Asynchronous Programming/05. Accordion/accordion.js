async function solution() {
    
    const main = document.getElementById('main');
    document.appendChild
    const url = `http://localhost:3030/jsonstore/advanced/articles/list`

    const res = await fetch(url);

    const data = (await res.json());

    data.forEach(element => {
        let accordion = createElement('accordion','',['class','accordion']);
        let headDiv = createElement('div','',['class','head']);
        let span = createElement('span',element.title);
        let button = createElement('button','MORE',['class','button','id',element._id]);
        let extraDiv = createElement('div','',['class','extra']);
        let p = createElement('p','');

        button.addEventListener('click', toggle);

        headDiv.appendChild(span);
        headDiv.appendChild(button)
        extraDiv.appendChild(p);

        accordion.appendChild(headDiv);
        accordion.appendChild(extraDiv);

        main.appendChild(accordion);

    });

}

async function toggle(event){

    let p = event.target.parentNode.parentNode.children[1].children[0];
    let extradiv = event.target.parentNode.parentNode.children[1];
    console.log(extradiv);
    
    let url = `http://localhost:3030/jsonstore/advanced/articles/details/${event.target.id}`

    const res = await fetch(url);
    const data =await  res.json();
    p.textContent=data.content;

    if(event.target.textContent =='MORE'){
        event.target.textContent='LESS'
        extradiv.style.display='block'
    }else{
        event.target.textContent='MORE'
        extradiv.style.display='none'
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

solution();