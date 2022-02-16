function solve() {
    let textElement = document.getElementById('input');
    let textArray = textElement.value.split('.').filter(s=>s!='');
    let outputElement=document.getElementById('output');

    while(textArray.length>0){
      let text = textArray.splice(0,3).join('.') + '.';
      let p = document.createElement('p');
      p.textContent=text;
      outputElement.appendChild(p);

    }
}