
function isUniqueBruteForce(inputString){
    if(inputString.lenght <= 1) return true;

    for(let index = 0; index < inputString.length; index++){
        for(let innerIndex = index+1; innerIndex < inputString.length; innerIndex++){
            if(inputString[index] === inputString[innerIndex]){
                return false;
            }
        }
    }
    return true;
}

function isUnique(inputString){
    if(inputString.length <= 0) return true;
    inputString = Array.from(inputString).sort().reduce( (p,c) => p + c);
    let current = inputString[0];
    for(let index = 1; index < inputString.length; index++){
        if(current === inputString[index]){
            return false;
        }
        else{
            current = inputString[index];
        }
    }

    return true;
}

function isUnique(inputString){
    if(inputString.length <= 1) return true;
    let hash = new Map();
    for(let index = 0; index < inputString.length; index++){
        if(hash.has(inputString[index])){
            return false
        }else{
            hash.set(inputString[index],true);
        }
    }

    return true;
}