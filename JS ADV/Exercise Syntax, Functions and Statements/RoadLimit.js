
function radar(speed, Area) {
    let speedLimit;
    if (Area == 'motorway') {
        speedLimit = 130;
    } else if (Area == 'interstate') {
        speedLimit = 90;
    } else if (Area == 'city') {
        speedLimit = 50;
    } else if (Area == 'residential') {
        speedLimit = 20;
    }

    if (speed <= speedLimit) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    } else {
        let speeding = speed - speedLimit;
        let status;
        if (speeding <= 20) {
            status = 'speeding';
        } else if (speeding <= 40) {
            status = 'excessive speeding';
        }
        else {
            status = 'reckless driving';
        }
        console.log(`The speed is ${speeding} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }

}