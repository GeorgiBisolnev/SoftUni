async function attachEvents() {

    let submit = document.getElementById('submit');
    let location = document.getElementById('location');

    const res = await fetch('http://localhost:3030/jsonstore/forecaster/locations')

    const data = await res.json();

    console.log(data);

    submit.addEventListener('click',getWeather);

    async function getWeather(){
        try {
            let code = '';
            for (let index = 0; index < data.length; index++) {
                if (data[index].name == location.value)
                    code = data[index].code;
            }

            const todayUrl = `http://localhost:3030/jsonstore/forecaster/today/${code}`

            const todayres = await fetch(todayUrl);
            const todaydata = await todayres.json();

            let weatherSymbol = getWatherSymbol(todaydata.forecast.condition);
            let hightemp = todaydata.forecast.high;
            let lowtemp = todaydata.forecast.low;
            let locationName = todaydata.name;

            //-------------------- prilagane na info ---------------------
            let currentDiv = document.getElementById('current');
            currentDiv.style.display='block'
            currentDiv.innerHTML = '';
            let currentConditionLabel = createElement('div', 'Current conditions', ['class', 'label']);
            currentDiv.appendChild(currentConditionLabel);
            let forecastDiv = createElement('div', '', ['class', 'forecasts'])
            let spanSymbol = createElement('span', '', ['class', 'condition symbol'])
            spanSymbol.innerHTML = weatherSymbol;
            forecastDiv.appendChild(spanSymbol);
            let locationNamespan = createElement('span', locationName, ['class', 'forecast-data']);
            let locationLowHighspan = createElement('span', '', ['class', 'forecast-data']);
            locationLowHighspan.innerHTML = `${lowtemp}${getWatherSymbol('Degrees')}/${hightemp}${getWatherSymbol('Degrees')}`;
            let locationcurrentweather = createElement('span', todaydata.forecast.condition, ['class', 'forecast-data']);

            let conditionspan = createElement('span', '', ['class', 'condition']);
            conditionspan.appendChild(locationNamespan);
            conditionspan.appendChild(locationLowHighspan);
            conditionspan.appendChild(locationcurrentweather);
            forecastDiv.appendChild(conditionspan);
            currentDiv.appendChild(forecastDiv);

            //--------------------------------------------- prilagane na info za 3 dni

            let upcomingDIV = document.getElementById('upcoming');
            upcomingDIV.innerHTML = '';
            upcomingDIV.style.display='block';
            let upcomminglabel = createElement('div', 'Three-day forecast', ['class', 'label']);
            upcomingDIV.appendChild(upcomminglabel);

            const upcomingURL = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`

            const upcomingRES = await fetch(upcomingURL);
            const upcomingDATA = await upcomingRES.json();



            let forecastinfoDIV = createElement('div', '', ['class', 'forecast-info'])
            let count = 0;
            upcomingDATA.forecast.forEach(element => {
                let forecastInfoSPANContainer = createElement('span', '', ['class', 'upcoming']);
                let forecastinfoSymbolSpan = createElement('span', '', ['class', 'symbol'])
                forecastinfoSymbolSpan.innerHTML = getWatherSymbol(element.condition);
                let forecastinfoDegreesSpan = createElement('span', '', ['class', 'forecast-data'])
                forecastinfoDegreesSpan.innerHTML = `${element.low}${getWatherSymbol('Degrees')}/${element.high}${getWatherSymbol('Degrees')}`
                let forecastinfoWeatherSpan = createElement('span', element.condition, ['class', 'forecast-data']);

                forecastInfoSPANContainer.appendChild(forecastinfoSymbolSpan);
                forecastInfoSPANContainer.appendChild(forecastinfoDegreesSpan);
                forecastInfoSPANContainer.appendChild(forecastinfoWeatherSpan);
                forecastinfoDIV.appendChild(forecastInfoSPANContainer);

                //console.log(count++);
            });
            upcomingDIV.appendChild(forecastinfoDIV);




            document.getElementById('forecast').style.display = 'block';

        }
        catch (error) {
 
            
            let upcomingDIV = document.getElementById('upcoming');
            upcomingDIV.style.display='none';
            let currentDiv = document.getElementById('current');
            currentDiv.style.display='none';
            alert('Error ' + error)
        }
    }

    function getWatherSymbol(value){
        if(value=='Sunny'){
            return '&#x2600'
        } else if(value=='Partly sunny'){
            return '&#x26C5'
        }else if(value =='Overcast'){
            return '&#x2601'
        }else if(value =='Rain'){
            return '&#x2614'
        } else if(value ==  'Degrees'){
            return '&#176'
        }
    }
    function createElement(type,content='',atributes=[]){

        const element = document.createElement(type);
    
        element.textContent = content;
    
            for (let i = 0; i < atributes.length; i+=2) {
                element.setAttribute(atributes[i],atributes[i+1])
            }
    
    
        return element;
    }
}   

attachEvents();