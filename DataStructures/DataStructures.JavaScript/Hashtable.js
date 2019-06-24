    class HashtableNode {
        constructor(key, value) {
            this._key = key;
            this._value = value;
            this._next = null;
        }

        get next(){
            return this._next;
        }

        set next(value) {
            this._next = value;
        }

        get value() {
            return this._value;
        }
        
        get key(){
            return this._key;
        }
    }

    class Hashtable {
        constructor(size = 10) {
            this._size = size;
            this._array = [];
        }

        get empty(){
            for(let index=0; index<this._size;index++){
                if(this._array !== undefined && this._array !== null){
                    return false;
                }
            }
            return true;
        }

        getHash(key) {
            let code = 0;
            for (let index = 0; index < key.length; index++) {
                code += key.charCodeAt(index);
            }
            return Math.pow(code, 2);
        }

        getIndex(hash) {
            return hash % this._size;
        }

        put(key, value){
            let newNode = new HashtableNode(key, value);
            let hash = this.getHash(key);
            let index = this.getIndex(hash);
            let node = this._array[index];
            if(node === undefined || node === null){
                this._array[index] = newNode;
            }else{
                while(node.next !== undefined && node.next !== null){
                    node = node.next;
                }
                node.next = newNode;
            }
        }

        get(key){
            let hash = this.getHash(key);
            let index = this.getIndex(hash);
            let node = this._getByIndex(index);
            while(node.key !== key){
                node = node.next;
            }

            return node.value;
        }

        delete(key){
            let hash = this.getHash(key);
            let index = this.getIndex(hash);
            let node = this._getByIndex(index);
            let previousNode = null;
            while(node.key !== key){
                previousNode = node;
                node = node.next;
            }

            if(previousNode == null){
                this._array[index] = node.next;
            }else{
                previousNode.next = node.next;
            }
        }

        getKeys(){
            return this.getAll("key");
        }

        getValues(){
            return this.getAll("value");
        }

        getAll(property){
            let properties = [];
            for(let index=0; index<this._array.length; index++){
                if(this._array[index] !== undefined)
                {
                    let node = this._array[index];
                    do{
                        properties.push(node[property]);
                        node = node.next;
                    }while(node !== undefined && node !== null)
                }
            }

            return properties;
        }

        _getByIndex(index){
            return this._array[index];
        }
    }