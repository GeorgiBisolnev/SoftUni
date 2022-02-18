window.addEventListener('load', solution);

function solution() {
  
  let fullnameElement = document.getElementById('fname');
  let emailElement = document.getElementById('email');
  let phoneElement = document.getElementById('phone');
  let addressElement = document.getElementById('address');
  let codeElement = document.getElementById('code');

  let submitElement = document.getElementById('submitBTN');

  let editElement = document.getElementById('editBTN');
  let continueElemen = document.getElementById('continueBTN');


  
  ///////////////information


  let ulElement = document.getElementById('infoPreview')

  submitElement.addEventListener('click',()=>{

     //information from fields
    let fullname = fullnameElement.value;
    let email = emailElement.value;
    let phone = phoneElement.value;
    let address = addressElement.value;
    let code = codeElement.value;

    if(fullnameElement.value!='' && emailElement.value!=''){

      // clear filds


      //submit butt disable
      submitElement.setAttribute('disabled',true)

      //create ul list
      let lifullname = document.createElement('li');
      let liemail = document.createElement('li');
      let liphone = document.createElement('li');
      let liaddress = document.createElement('li');
      let licode = document.createElement('li');
      
      //set textcontent to li elements

      lifullname.textContent='Full Name: '+ fullnameElement.value;
      liemail.textContent='Email: ' + emailElement.value;
      liphone.textContent = 'Phone Number: ' + phoneElement.value;
      liaddress.textContent='Address: ' + addressElement.value;
      licode.textContent='Postal Code: ' + codeElement.value;


      //add li elements to UL

      ulElement.appendChild(lifullname);
      ulElement.appendChild(liemail);
      ulElement.appendChild(liphone);
      ulElement.appendChild(liaddress);
      ulElement.appendChild(licode);

      //action buttons enabled

      editElement.disabled=false;
      continueElemen.disabled=false;
      // action button edit

      editElement.addEventListener('click',()=>{
        lifullname.remove();
        liemail.remove();
        liphone.remove();
        liaddress.remove();
        licode.remove();

        fullnameElement.value= fullname;
        emailElement.value = email;
        phoneElement.value= phone;
        addressElement.value=address;
        codeElement.value=code;

        editElement.disabled=true;
        continueElemen.disabled=true;
        submitElement.disabled=false;

      })


      fullnameElement.value='';
      emailElement.value='';
      phoneElement.value='';
      addressElement.value='';
      codeElement.value='';
    }
  })

  continueElemen.addEventListener('click',()=>{

    let mainDivBlock = document.getElementById('block');
    mainDivBlock.innerHTML='';

    let h3element = document.createElement('h3');
    h3element.textContent='Thank you for your reservation!'
    mainDivBlock.appendChild(h3element);
  })

}
