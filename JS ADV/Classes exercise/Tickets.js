function solve(tickets,sortCriteria){
    class TicketClass{
        constructor(destination,price,status){
            this.destination =destination;
            this.price=Number(price);
            this.status=status;
        }
    }
    let listOfTickets=[];
    for (const ticket of tickets) {
        let [destinationName,price,status] = ticket.split('|');
        let curTicket = new TicketClass(destinationName,price,status);
        listOfTickets.push(curTicket);
    }

    
    // listOfTickets.sort(function(a,b){
    //     if(a[sortCriteria] > b[sortCriteria]) return 1; 
    //     if(a[sortCriteria] < b[sortCriteria]) return -1; 
    //     if(a[sortCriteria] = b[sortCriteria]) return 0; 
    //  });

     if(sortCriteria=='status'){
          listOfTickets.sort((a,b)=> a.status.localeCompare(b.status));
     } else if(sortCriteria=='destination'){
         listOfTickets.sort((a,b)=> a.destination.localeCompare(b.destination));
     } else{
         listOfTickets.sort((a,b)=> a.price-b.price);
     }
    
    console.log(listOfTickets);
    return listOfTickets;
}

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'status')