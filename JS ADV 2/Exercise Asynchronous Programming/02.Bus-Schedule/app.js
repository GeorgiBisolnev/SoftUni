function solve() {

    const label = document.querySelector('#info span');
    const departBut = document.getElementById('depart');
    const arriveBut = document.getElementById('arrive');

    let stop ={
        next :'depot'
    }
    async function depart() {
        const url = `http://localhost:3030/jsonstore/bus/schedule/${stop.next}`

        const res = await fetch(url);

        stop =  await res.json();

        label.textContent = `Next stop ${stop.name}`;
        departBut.disabled = true;
        arriveBut.disabled=false;

    }

    function arrive() {
        label.textContent  = `Arriving at ${stop.name}`
        departBut.disabled = false;
        arriveBut.disabled=true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();