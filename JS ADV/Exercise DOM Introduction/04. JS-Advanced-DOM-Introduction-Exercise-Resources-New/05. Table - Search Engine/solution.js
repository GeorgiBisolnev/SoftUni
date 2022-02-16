function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let inputtext = document.getElementById('searchField');
      let rows = document.querySelectorAll('tbody tr');

      for (const row of rows) {
         if(inputtext.value!=='' && row.innerHTML.includes(inputtext.value)){
            row.className='select';
         } else{
            row.classList.remove('select');
         }
      }
      inputtext.value='';
   }
}