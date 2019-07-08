class QueueNode{
    constructor(value){
        this._value = value;
        this._next = null;
    }

    set next(value){
        this._next = value;
    }

    get next(){
        return this._next;
    }

    get value(){
        return this._value;
    }
}

class Queue{
    constructor(value){
        this._size = 0;

        if (value === undefined){
            this._first = null;
            this._last = null;
        }
        else{
            this.enqueue(value);
        }
    }

    enqueue(value){
        let newNode = new QueueNode(value);
        if(this.empty){
            this._first = newNode;
        }else{
            this._last.next = newNode;
        }
        this._last = newNode;
        this._size++;
    }

    dequeue(){
        let itemToRemove = this._first;
        this._first = itemToRemove.next;
        this._size--;
        return itemToRemove.value;
    }

    peek(){
        return this._first.value;
    }

    toArray(){
        let array = [];
        while(this._size > 0){
            array.push(this.dequeue());
        }
        return array;
    }

    get size(){
        return this._size;
    }

    get empty(){
        return this.size === 0;
    }

    get headAndTail(){
        return [this.dequeue(), this];
    }


}