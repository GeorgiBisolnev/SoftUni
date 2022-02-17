function solve(inputObj){
    
    let method = ['GET', 'POST', 'DELETE' , 'CONNECT']
    let version = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1' , 'HTTP/2.0']

    if(!method.includes(inputObj['method'])){
        throw new Error (`Invalid request header: Invalid Method`);
    }

    if(!version.includes(inputObj['version'])){
        throw new Error (`Invalid request header: Invalid Version`);
    }

    let regExURI = /^[a-z0-9\*\.]+$/gim;
    let isValidURI = regExURI.test(inputObj['uri']);

    if(!isValidURI){
        throw new Error('Invalid request header: Invalid URI')
    }

    regExMessage= /^[^<>"\\&'\r\n]*$/gm;
    let usValidMessage = regExMessage.test(inputObj['message'])

    if(!usValidMessage){
        throw new Error('Invalid request header: Invalid Message')
    }
return inputObj;

}

solve({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
  })