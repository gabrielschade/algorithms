class LinkedListNode {
    constructor(value) {
        this._value = value;
        this._next = null;
    }

    get next() {
        return this._next;
    }

    set next(value) {
        this._next = value;
    }

    get value() {
        return this._value;
    }
}

class LinkedList {
    constructor(value) {
        this._head = null;
        this._size = 0;

        if (value !== undefined) {
            if (Array.isArray(value)) {
                for(let element of value)
                    this.append(element);
            }else{
                this.append(value);
            }
        }
    }

    get size() {
        return this._size;
    }

    get isEmpty() {
        return this.size === 0;
    }

    get head() {
        return this._head;
    }

    set head(value) {
        this._head = value;
    }

    get(index) {
        let [currentNode,_] = this._getByIndex(index);
        return currentNode.value;
    }

    _getByIndex(index) {
        let previousNode = null;
        let currentNode = this.head;
        while (index > 0) {
            previousNode = currentNode;
            currentNode = currentNode.next;
            index--;
        }

        return [currentNode, previousNode];
    }

    insertAt(value, index) {
        let [_,previous] = this._getByIndex(index);
        this.insert(previous, value);
    }

    insert(node, value) {
        let newNode = new LinkedListNode(value);
        if (node == null) {
            newNode.next = this.head;
            this.head = newNode;
        }
        else {
            let next = node.next;
            node.next = newNode;
            node.next.next = next;
        }

        this._size = this._size + 1;
        return node;
    }

    add(value){
        this.insert(null, value);
    }

    append(value) {
        this.insertAt(value, this._size);
    }

    remove(index) {
        let [currentNode, previousNode] = this._getByIndex(index);

        if (previousNode !== null) {
            previousNode.next = currentNode.next;
        } else {
            this._head = currentNode.next;
        }

        this._size = this._size - 1;
    }


        *values() {
            let current = this.head;
            while (current !== null) {
                yield current.value;
                current = current.next;
            }
        }

        [Symbol.iterator]() {
            return this.values();
        }

    toArray(){
        let array = [];
        for(let node of this)
            array.push(node);

        return array;
    }
}