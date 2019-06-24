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
                let array = value;
                if (!Array.isArray(value)) {
                    array = [value];
                }

                let head = new LinkedListNode(array[0]);
                let previousNode = head;

                for (let index = 1; index < array.length; index++) {
                    let node = new LinkedListNode(array[index]);
                    previousNode.next = node;
                    previousNode = node;
                }

                this._head = head;
                this._size = array.length;
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

        add(value) {
            let newNode = new LinkedListNode(value);
            let node = this.head;
            if (node === null) {
                this._head = newNode;
            } else {
                while (node.next !== null) {
                    node = node.next;
                }
                node.next = newNode;
            }

            this._size = this._size + 1;
        }

        get(index) {
            let currentNode = this._getByIndex(index,
                (current, previous) => current
            );

            return currentNode.value;
        }

        remove(index) {
            let [currentNode, previousNode] = this._getByIndex(index,
                (current, previous) => [current,previous]   
            );

            if (previousNode !== null) {
                previousNode.next = currentNode.next;
            } else {
                this._head = currentNode.next;
            }

            this._size = this._size - 1;
        }

        _getByIndex(index, action) {
            let previousNode = null;
            let currentNode = this.head;
            while (index > 0) {
                previousNode = currentNode;
                currentNode = currentNode.next;
                index--;
            }

            return action(currentNode, previousNode);
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
    }