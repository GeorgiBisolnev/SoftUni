function solve() {
    let firstnameElement = document.getElementById('fname');
    let lastnameElement = document.getElementById('lname');
    let emailElement = document.getElementById('email');
    let birthElement = document.getElementById('birth');
    let positionElement = document.getElementById('position');
    let salaryElement = document.getElementById('salary');

    let hireButtonElement = document.getElementById('add-worker')

    let tableBody = document.getElementById('tbody');

    hireButtonElement.addEventListener('click',(event)=>{
        event.preventDefault();
        firstname = firstnameElement.value;
        lastname= lastnameElement.value;
        email = emailElement.value; 
        birth = birthElement.value; 
        postion = positionElement.value;
        salary = Number(salaryElement.value); 

        if(firstname!='' && lastname!='' && email!='' && birth!='' && postion!='' && salaryElement.value!=''){

            let fnametd = document.createElement('td');
            let lastnametd = document.createElement('td');
            let emailtd = document.createElement('td');
            let birthtd = document.createElement('td');
            let postiontd = document.createElement('td');
            let salarytd = document.createElement('td');
            let actiontd = document.createElement('td');

            let firedElement = document.createElement('button');
                firedElement.classList.add('fired');
                firedElement.textContent='Fired';
            let editElement = document.createElement('button');
                editElement.classList.add('edit');
                editElement.textContent='Edit';
            
            actiontd.appendChild(firedElement); actiontd.appendChild(editElement);

            let row = document.createElement('tr');
            
            fnametd.textContent=firstname;
            lastnametd.textContent=lastname;
            emailtd.textContent=email;
            birthtd.textContent = birth;
            postiontd.textContent= postion;
            salarytd.textContent = salary;

            row.appendChild(fnametd);
            row.appendChild(lastnametd);
            row.appendChild(emailtd);
            row.appendChild(birthtd);
            row.appendChild(postiontd);
            row.appendChild(salarytd);
            row.appendChild(actiontd);

            editElement.addEventListener('click',()=>{
                firstnameElement.value=fnametd.textContent;
                lastnameElement.value=lastnametd.textContent;
                emailElement.value=emailtd.textContent;
                birthElement.value=birthtd.textContent; 
                positionElement.value=postiontd.textContent;
                salaryElement.value=salarytd.textContent;

                let sumElement = document.getElementById('sum');
                sumElement.textContent = (Number(sumElement.textContent)- Number(salarytd.textContent)).toFixed(2);
                row.remove();
            })

            firedElement.addEventListener('click',()=>{
                let sumElement = document.getElementById('sum');
                sumElement.textContent = (Number(sumElement.textContent)- Number(salarytd.textContent)).toFixed(2);
                row.remove();
            })

            
            let sumElement = document.getElementById('sum');
            sumElement.textContent = (Number(sumElement.textContent)+ Number(salary)).toFixed(2);
            tableBody.appendChild(row);
            firstnameElement.value='';
            lastnameElement.value='';
            emailElement.value=''; 
            birthElement.value=''; 
            positionElement.value='';
            salaryElement.value='';
        }


    })
}
solve()