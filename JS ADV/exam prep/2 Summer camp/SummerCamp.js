class SummerCamp{
    constructor(organizer,location){
        this.organizer=organizer;
        this.location=location;
        this.priceForTheCamp={
            "child": 150,
            "student": 300,
            "collegian": 500
        };
        this.listOfParticipants=[];
    }

    registerParticipant(name,condition,money){
        
        if(condition!='child' && condition!='student' && condition!='collegian'){
            throw new Error('Unsuccessful registration at the camp.')
        }

        for (const participant of this.listOfParticipants) {
            if(participant['name']===name){
                return `The ${name} is already registered at the camp.`;
            }
        }

        if(this.priceForTheCamp[condition]>money){
            return `The money is not enough to pay the stay at the camp.`;            
        }

        let newParticipant={
            'name': name,
            'condition':condition,
            'power':100,
            'wins':0,            
        }
        this.listOfParticipants.push(newParticipant);

        return `The ${name} was successfully registered.`
    }
    unregisterParticipant(name){

        for(let i=0;i<this.listOfParticipants.length;i++){

            if(this.listOfParticipants[i]['name']===name){
                this.listOfParticipants.splice(i,1);
                return `The ${name} removed successfully.`
            }
        }

        throw new Error(`The ${name} is not registered in the camp.`);
    }
    timeToPlay(typeOfGame,...participants){
        let participant1 = this.listOfParticipants.find(x=>x.name === participants[0]);
        let participant2 = this.listOfParticipants.find(x=>x.name === participants[1]);

        if(typeOfGame=='WaterBalloonFights'){
            if(participant1== undefined || participant2== undefined){
                throw new Error('Invalid entered name/s.')
            }

            if(participant1['condition']!=participant2['condition']){
                throw new Error('Choose players with equal condition.')
            }

            if(participant1['power']===participant2['power']){
                return 'There is no winner.'
            } else if(participant1['power']>participant2['power']){
                participant1['wins']++;
                return `The ${participant1['name']} is winner in the game ${typeOfGame}.`
            } else {
                participant2['wins']++;
                return `The ${participant2['name']} is winner in the game ${typeOfGame}.`
            }


        } else if(typeOfGame=='Battleship'){
            if(participant1==undefined){
                throw new Error('Invalid entered name/s.')
            }

            participant1['power']+=20;
            return `The ${participant1['name']} successfully completed the game ${typeOfGame}.`;

        }


    }
    toString(){
        let result =`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}\n`

        let ordered = this.listOfParticipants.sort((a,b)=>b['wins']-a['wins']);

        for (const human of ordered) {
            result+=`${human['name']} - ${human['condition']} - ${human['power']} - ${human['wins']}\n`;
        }

        return result.trim();
    }
}

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
//console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

console.log(summerCamp.toString());

