function create(words) {
   let content = document.getElementById('content');
   for (const word of words) {

      let div = document.createElement('div');
      let p = document.createElement('p');
         p.textContent=word;
         p.style.display='none';
      div.appendChild(p);
      div.addEventListener('click', showp);
      content.appendChild(div);
      
   }

   function showp(e){
         e.target.children[0].style.display='block'
   }
}