function solve(message){

    let divElement = document.getElementById('notification');

    divElement.style.display='block';
    divElement.textContent=message;

    divElement.addEventListener('click',hideOnClick);

    function hideOnClick(){

        divElement.style.display='none';
    }
}