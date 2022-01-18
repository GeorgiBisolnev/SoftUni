function solve(num){
    let number = Number(num.toString()[0]);
    let bol = num.toString().split('').every(a => a == number);
    let str = num.toString().split('');
    let sum=0;
    str.forEach(element => {
        sum+=Number(element);
    });

    console.log(bol);
    console.log(sum);
}

solve(8888);