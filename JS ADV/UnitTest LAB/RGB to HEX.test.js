const {assert} = require('chai');
const rgbToHexColor = require('./RGB to HEX');

describe('Sledvashta zadacha 6 ',()=>{
    it('Shuld work',()=>{

        assert.equal(rgbToHexColor(5,100,55),'#056437')
        assert.equal(rgbToHexColor(255,0,255),'#FF00FF')
        assert.equal(rgbToHexColor(0,0,0),'#000000')

    })

    it('Shuld return undefined if ut of RGB range',()=>{

        assert.equal(rgbToHexColor(5,100,300),undefined)
        assert.equal(rgbToHexColor(255,300,255),undefined)
        assert.equal(rgbToHexColor(256,0,0),undefined)
        assert.equal(rgbToHexColor(-1,100,55),undefined)
        assert.equal(rgbToHexColor(255,-1,255),undefined)
        assert.equal(rgbToHexColor(0,0,-1),undefined)

    })

    it('Shuld not work if type input is incorect',()=>{

        assert.equal(rgbToHexColor('5',100,300),undefined)
        assert.equal(rgbToHexColor(255,'300','255'),undefined)
        assert.equal(rgbToHexColor(256,0,null),undefined)
        assert.equal(rgbToHexColor(-1,undefined,55),undefined)
        assert.equal(rgbToHexColor(255,-1,{1:2}),undefined)
        assert.equal(rgbToHexColor(0,0,[1,2]),undefined)

    })
})