function validate() {
    let submitButton = document.getElementById('submit');
    submitButton.addEventListener('click', func);
    let usernameInput = document.getElementById('username');
    let passwordInput = document.getElementById('password')
    let confirmPasswordInput = document.getElementById('confirm-password');
    let mailinput = document.getElementById('email');
    let checkboxelement = document.getElementById('company');
        checkboxelement.addEventListener('click',onClickShowCompany);
    let companyField = document.getElementById('companyInfo');
    let companyNumberElement = document.getElementById('companyNumber');
    let validElement = document.getElementById('valid');

    function func(event){
        event.preventDefault()
        
        let regi = /^[a-zA-Z0-9]{3,20}$/g;
        let isValidusername = regi.test(usernameInput.value);

        if(!isValidusername){
            usernameInput.style.borderColor='red'
        } else {
            usernameInput.style.borderColor=''
        }
        
        regi= /^[a-zA-Z0-9\_]{5,15}$/g

        let isValidPassword = regi.test(passwordInput.value);
        if(!isValidPassword){
            passwordInput.style.borderColor='red'
        } else {
            passwordInput.style.border=''
        }
        let isSamePasswordInputed = (passwordInput.value===confirmPasswordInput.value && isValidPassword)
        if(!isSamePasswordInputed){
            confirmPasswordInput.style.borderColor='red'
        } else {
            confirmPasswordInput.style.border=''
        }

        regi = /^[^@.]*\@[^@]*\.[^@]*$/g;
        let isValidMail = regi.test(mailinput.value);
        if(!isValidMail){
            mailinput.style.borderColor='red'
        } else {
            mailinput.style.border=''
        }

        let isValidComapnyNumber = Number(companyNumberElement.value)>1000 && Number(companyNumberElement.value)<9999;
        if(!isValidComapnyNumber){
            companyNumberElement.style.borderColor='red'
        } else {
            companyNumberElement.style.border=''
        }

        // alert(`username ${isValidusername}\n
        // pass ${isValidPassword}\n
        // twoPassSame ${isSamePasswordInputed}\n
        // email ${isValidMail}\n
        // isValidCompNum ${isValidComapnyNumber}` );

        if(checkboxelement.checked){
            if(isValidComapnyNumber && isValidMail && isValidPassword && isValidusername && isSamePasswordInputed){
                validElement.style.display='block';
            } else{
                validElement.style.display='none'
            }
        } else if(!checkboxelement.checked){
            if(isValidMail && isValidPassword && isValidusername && isSamePasswordInputed){
                validElement.style.display='block';
            } 
            else{
                validElement.style.display='none'
            }
        } 

        
    }

    function onClickShowCompany(){        
        if(checkboxelement.checked ==true){
            companyField.style.display='block';
        }
        else {
            companyField.style.display='none';
        }
    }



}
