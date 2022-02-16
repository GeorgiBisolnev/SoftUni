function encodeAndDecodeMessages() {

    let codeButton = document.querySelector('button');
    let decodeButton = document.querySelectorAll('button')[1];

    codeButton.addEventListener('click',codeOnClick);
    decodeButton.addEventListener('click',decodeOnClick);

    function codeOnClick(){
        let textAreas = document.querySelectorAll('textarea')
        let inputText = textAreas[0];
        let resultText = textAreas[1];
        resultText.value = codeText(inputText.value);
        inputText.value='';
    }

    function decodeOnClick(){
        let textAreas = document.querySelectorAll('textarea');
        let textArea = textAreas[1];

        textArea.value = decodeText(textArea.value);
    }

    
    function codeText(str){
        let result=''
        for(let i=0;i<str.length;i++){
            result+=String.fromCharCode(str.charCodeAt(i)+1);
        }
        return result;
    }

    function decodeText(str){
        let result=''
        for(let i=0;i<str.length;i++){
            result+=String.fromCharCode(str.charCodeAt(i)-1);
        }
        return result;
    }
}