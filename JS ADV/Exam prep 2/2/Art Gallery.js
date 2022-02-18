class ArtGallery{
    constructor(creator){
        this.creator=creator;
        this.possibleArticles={
            "picture":200,
            "photo":50,
            "item":250
        };
        this.listOfArticles=[];
        this.guests=[];
    }

    addArticle(articleModel, articleName, quantity ){
        let flag=false;
        for (const key in this.possibleArticles) {
            if(key.toUpperCase()===articleModel.toUpperCase()){
                flag=true;
            }
        }
        if(flag==false){
            throw new Error('This article model is not included in this gallery!');
        }

        let newObj ={
            'articleModel':articleModel.toLowerCase(),
            'articleName':articleName,
            'quantity':Number(quantity)
        }

        for (const article of this.listOfArticles) {
            if(article['articleName'].toLowerCase()==newObj['articleName'].toLowerCase() 
                                        && article['articleModel']==articleModel.toLowerCase()){
                article['quantity']+=Number(quantity);
                return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;                            
            }
        }

        this.listOfArticles.push(newObj);
        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }
    inviteGuest( guestName, personality){

        for (const key of this.guests) {
            if(key['guestName']==guestName){
                throw new Error(`${guestName} has already been invited.`);                
            }
        }
        let points;
        if(personality=='Vip'){
            points=500;
        } else if(personality=='Middle'){
            points=250;
        } else{
            points=50;
        }
        let newGuest ={
            'guestName':guestName,
            'points': points,
            'purchaseArticle':0,
        }
        this.guests.push(newGuest);
        return `You have successfully invited ${guestName}!`        

    }
    buyArticle ( articleModel, articleName, guestName){

        let article = this.listOfArticles.find(element=> element['articleName']==articleName && element['articleModel'].toUpperCase()==articleModel.toUpperCase())

        if(article==undefined){
            throw new Error(`This article is not found.`);
        }

        if(article['quantity']==0){
            return `The ${articleName} is not available.`
        }
        let guest = this.guests.find(element=>element['guestName']==guestName);

        if(guest==undefined){
            return `This guest is not invited.`;
        }

        let neededPoints = this.possibleArticles[articleModel.toLowerCase()]
        if(neededPoints<=guest['points']){
            for (const guest of this.guests) {
                if(guest['guestName']==guestName){
                    guest['points']-=neededPoints;
                    guest['purchaseArticle']++;
                }                
            }
            for (const article of this.listOfArticles) {
                if(article['articleModel'].toLowerCase()==articleModel.toLowerCase() &&
                articleName==article['articleName']){
                    article['quantity']--;
                }
            }
            return `${guestName} successfully purchased the article worth ${neededPoints} points.`
        } else{
            return 'You need to more points to purchase the article.';
        }
    }
    showGalleryInfo (criteria){
        let result=''
        if(criteria=='article'){
            result='Articles information:\n';
            for (const article of this.listOfArticles) {
                result+=`${article['articleModel']} - ${article['articleName']} - ${article['quantity']}\n`
            }
        } else{
            result='Guests information:\n';
            for (const guest of this.guests) {
                result+=`${guest['guestName']} - ${guest['purchaseArticle']}\n`
            }
        }

        return result.trim();
    }
}
const artGallery = new ArtGallery('Curtis Mayfield'); 
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest'));