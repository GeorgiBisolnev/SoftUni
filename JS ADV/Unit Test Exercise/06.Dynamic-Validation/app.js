function validate() {
    
    let textElement = document.getElementById('email');
    textElement.addEventListener('change',validate);
    let regi = /^[a-z]+@[a-z]+\.[a-z]+$/g;

    let isValidMail = regi.test(textElement.value);

    if(!isValidMail){
        textElement.classList.add('error')
    } else{
        textElement.classList.remove('error')
    }
    
}