function demo(steps, length, speed){
    let distance = steps * length;
    distance /= 1000;
    let timeInHours = distance / speed;
    let timeInMinutes = timeInHours * 60;
    let restTime = Math.floor((distance * 1000) / 500);
    timeInMinutes += restTime;
    let h;
    let m;
    let ss;
    h = Math.floor(timeInMinutes / 60).toString().padStart(2, '0');
    m = (Math.floor(timeInMinutes % 60)).toString().padStart(2, '0');

    ss = (Math.round((timeInMinutes - Math.floor(timeInMinutes)) * 60)).toString().padStart(2, '0');

    console.log(`${h}:${m}:${ss}`);
}
demo(4000, 0.6, 5);
demo(2564, 0.70, 5.5);

