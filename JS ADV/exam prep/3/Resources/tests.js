let { Repository } = require("./solution.js");
let expect = require('chai').expect;

describe("repository tests", function () {
    let properties = {
        name: "string",
        age: "number",
        birthday: "object"
    };
    let entity = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7)
    };
    


    it("proprty", function () {
        let repo = new Repository(properties);
        expect(repo).to.haveOwnProperty('props')
        expect(repo.data).instanceOf(Map);
    });
    describe("adding tests", () => {
        it("adding tests", function () {
            let repo = new Repository(properties);
            expect(repo.add(entity)).to.be.equals(0)
            expect(repo.add(entity)).to.be.equals(1)
            let objTest = { "name": "Pesho", "age": 22, "birthday": new Date(1998, 0, 7) }
            expect(repo.getId(1)).to.deep.equals(objTest)
        });

        it("add wrong entity shuld thow an error",()=>{
            let repo = new Repository(properties);
            let anotherEntity = {
                name1: 'Stamat',
                age: 29,
                birthday: new Date(1991, 0, 21)
            };
            let anotherEntity1 = {
                name: 'Stamat',
                age1: 29,
                birthday: new Date(1991, 0, 21)
            };
            let anotherEntity2 = {
                name: 'Stamat',
                age: 29,
                birthday1: new Date(1991, 0, 21)
            };

            expect(() => repo.add(anotherEntity)).to.throw(Error, `Property name is missing from the entity!`);
            expect(() => repo.add(anotherEntity1)).to.throw(Error, `Property age is missing from the entity!`);
            expect(() => repo.add(anotherEntity2)).to.throw(Error, `Property birthday is missing from the entity!`);

            anotherEntityType1 = {
                name: 123,
                age: 29,
                birthday: new Date(1991, 0, 21)
            };
            anotherEntityType2 = {
                name: 'Stamat',
                age: '29.1',
                birthday: new Date(1991, 0, 21)
            };
            anotherEntityType3 = {
                name: 'Stamat',
                age: 29,
                birthday: 1991
            };
            expect(() => repo.add(anotherEntityType3)).to.throw(TypeError, `Property birthday is not of correct type!`);
            expect(() => repo.add(anotherEntityType2)).to.throw(TypeError, `Property age is not of correct type!`);
            expect(() => repo.add(anotherEntityType1)).to.throw(TypeError, `Property name is not of correct type!`);
        })
    })

    describe("repository tests", ()=> {
        it("Update", function () {
            let repo = new Repository(properties);
            expect(repo.add(entity)).to.be.equals(0)
            expect(repo.add(entity)).to.be.equals(1)
            let entityGosho = {
                'name': 'Gosho',
                'age': 22,
                'birthday': new Date(1998, 0, 7)
            };
            repo.update(1, entityGosho)

            expect(repo.getId(1)).to.deep.equals(entityGosho)
        });

        it("repository count size",()=>{
            let repo = new Repository(properties);
            repo.add(entity);
            repo.add(entity);
            expect(repo.count).to.be.equals(2);

        })

        it("delete from repository",()=>{
            let repo = new Repository(properties);
            repo.add(entity);
            repo.add(entity);
            expect(()=> repo.del(-1)).to.throw(Error,'Entity with id: -1 does not exist!')
            repo.del(1)
            let objTest = { "name": "Pesho", "age": 22, "birthday": new Date(1998, 0, 7) }
            expect(repo.getId(1)).to.deep.equals(objTest)
            expect(() => repo.del('test')).to.throw(`Entity with id: test does not exist!`);
        })

    })


});
