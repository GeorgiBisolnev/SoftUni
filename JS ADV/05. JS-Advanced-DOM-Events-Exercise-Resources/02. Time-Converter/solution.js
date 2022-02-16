function attachEventsListeners() {
    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');

    let rations ={
        days:1,
        hours:24,
        minutes:1440,
        seconds:86400
    }

    document.getElementById('daysBtn').addEventListener('click', convert);
    document.getElementById('hoursBtn').addEventListener('click', convert);
    document.getElementById('minutesBtn').addEventListener('click', convert);
    document.getElementById('secondsBtn').addEventListener('click', convert);

    function convert(event){
        
        let valueCalc = Number(event.currentTarget.previousElementSibling.value);
        if(event.target.id=='daysBtn'){
            hours.value=valueCalc*24;
            minutes.value=valueCalc*1440;
            seconds.value=valueCalc*86400;
        } 
        if(event.target.id=='hoursBtn'){
            days.value=valueCalc/24;
            minutes.value=valueCalc*60;
            seconds.value=valueCalc*60*60;
        }
        if(event.target.id=='minutesBtn'){
            days.value=valueCalc/24/60;
            hours.value=valueCalc/60;
            seconds.value=valueCalc*60;
        }
        if(event.target.id=='secondsBtn'){
            days.value=valueCalc/60/60/24;
            hours.value=valueCalc/60/60;
            minutes.value=valueCalc/60;
        }
    }
}