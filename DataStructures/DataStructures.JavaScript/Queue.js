class QueueNode{
    constructor(value){
        this._value = value;
        this._next = null;
    }

    set next(value){
        this._next = value;
    }

    get value(){
        return this._value;
    }
}

class Queue{
    constructor(value){
        if(value === undefined){
            this._first = null;
            this._last = null;
        }
        else{
            this._first = new QueueNode(value);
            this._last = this._first;
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
    }

    dequeue(){
        if(this.empty) throw new Error("Empty Queue");
        let itemToRemove = this._first;
        this._first = itemToRemove._next;
        return itemToRemove.value;
    }

    peek(){
        if(this.empty) throw new Error("Empty Queue");

        return this._first.value;
    }

    get empty(){
        return this._first === null;
    }
}