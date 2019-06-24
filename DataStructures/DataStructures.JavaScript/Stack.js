class StackNode {
    constructor(value) {
        this._value = value;
        this._next = null;
    }

    set next(next) {
        this._next = next;
    }

    get value() {
        return this._value;
    }
}

class Stack {
    constructor(value) {
        this._size = 0;

        if (value === undefined){
            this._head = null;
        }
        else{
            this.push(value);
        }
    }

    get empty() {
        return this._head == null;
    }

    get head(){
        return this._head.value;
    }

    get size(){
        return this._size;
    }

    get headAndTail(){
        return [this.pop(), this];
    }

    push(value) {
        this._size = this._size +1;
        let newHead = new StackNode(value);
        newHead.next = this._head;
        this._head = newHead;
    }

    pop() {
        this._size = this._size -1;
        let valueToReturn = this._head;
        this._head = valueToReturn._next;

        return valueToReturn.value;
    }

    peek() {
        return this._head.value;
    }

    toArray(){
        let array = [];
        while(this._size > 0){
            array.push(this.pop());
        }
        return array;
    }

    toArrayRecursive(){
        let recursiveLoopToArray = (stack, array) => {
            if(stack.size == 0) return array;

            let [head, tail] = stack.headAndTail;
            array.push(head);
            return recursiveLoopToArray(tail, array);
        }

        return recursiveLoopToArray(this,[]);
    }

}
