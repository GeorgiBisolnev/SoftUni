function lockedProfile() {
    
    Array.from(document.querySelectorAll('.profile button')).forEach(x=>x.addEventListener('click',onClick));

    function onClick(ev){
        let button = ev.currentTarget;
        let radioButton = button.parentElement.querySelector('input');
        let hidenDiv=ev.currentTarget.previousElementSibling;
        if(!radioButton.checked && hidenDiv.style.display!='block'){            
            hidenDiv.style.display='block'
            button.textContent = 'Hide it'
        } else if(!radioButton.checked && hidenDiv.style.display=='block'){
            
            hidenDiv.style.display='none'
            button.textContent = 'Show more'
        }
        
    }
}