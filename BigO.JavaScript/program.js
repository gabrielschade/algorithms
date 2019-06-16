const isEvenAt = (array, index) => array[index] % 2 == 0;

function containsValue(array, value){
    for(let number of array){
        if(number === value)
            return true;
    }
    return false;
}

function containsDuplicatedValues(array){
    for(let index =0; index < array.length; index++){
        for( let innerIndex =0; innerIndex < array.length; innerIndex++){
            if( index !== innerIndex 
                && array[index] == array[innerIndex]){
                    return true;
                }
        }
    }
    return false;
}

function binarySearch(array, value){
    let first = 0;
    let last = array.length -1;
    let index = 0;
    while(first <= last){
        index = parseInt( (first + last)/2 );
        if(value > array[index]){
            first = index + 1;
        }
        else if (value < array[index] ){
            last = index-1;
        }
        else if (array[index] === value){
            return true;
        }
    }
    return false;
}

const exponential = (number) => 
    number <= 1 
    ? number
    : exponential(number - 1) + exponential(number -1);