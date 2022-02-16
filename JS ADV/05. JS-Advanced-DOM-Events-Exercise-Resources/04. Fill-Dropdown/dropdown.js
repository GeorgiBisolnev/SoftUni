function addItem() {
    let menu = document.getElementById('menu');
    let inputvalue = document.getElementById('newItemValue');
    let inputtext = document.getElementById('newItemText');
    let newoption = document.createElement('option');

    newoption.value=inputvalue.value;
    newoption.text=inputtext.value;

    menu.appendChild(newoption);
    inputvalue.value='';
    inputtext.value='';
}