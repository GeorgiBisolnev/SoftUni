const url='http://localhost:3030/jsonstore/collections/students'
const tableBody = document.querySelector('#results tbody');

async function solve(){
 

    let form = document.getElementById('form');
    
    loadStudents();
    form.addEventListener('submit', async (e)=>{
        e.preventDefault();
        tableBody.innerHTML='';
        let formdata = new FormData(form);

        let firstName=formdata.get('firstName');
        let lastName=formdata.get('lastName');
        let facultyNumber=formdata.get('facultyNumber');
        let grade=formdata.get('grade');

        await fetch(url,{
            method:'POST',
            headers:{
                'Content-Type': 'application/json'
            },
            body:JSON.stringify({firstName,lastName,facultyNumber,grade            })
        })
        loadStudents();
    })

}

async function loadStudents(){
    

    let res = await fetch(url)
    let data = await res.json();

    let students = Object.values(data);

    students.forEach(s=>{
        let row = document.createElement('tr');
        let col1 = document.createElement('td');
        col1.textContent=s.firstName;
        let col2 = document.createElement('td');
        col2.textContent=s.lastName;
        let col3 = document.createElement('td');
        col3.textContent =s.facultyNumber;
        let col4 = document.createElement('td');
        col4.textContent=s.grade;

        row.appendChild(col1)
        row.appendChild(col2)
        row.appendChild(col3)
        row.appendChild(col4)
        tableBody.appendChild(row);

    })
}

solve()    

