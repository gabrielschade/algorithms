class TreeNode{
    constructor(value){
        this._value = value;
        this._left = this._right = null;
    }

    get value(){
        return this._value;
    }

    get left(){
        return this._left;
    }

    set left(value){
        this._left = new TreeNode(value);
    }

    get right(){
        return this._right;
    }

    set right(value){
        this._right = new TreeNode(value);
    }
}

class Tree{
    constructor(root){
        this._root = new TreeNode(root);
    }

    get root(){
        return this._root;
    }

    print(){
        let stack = [this.root];
        while(stack.length > 0){
            let current = stack.pop();
            if(current.right != null){
                stack.push(current.right);
            }
            if(current.left != null){
                stack.push(current.left);
            }
            console.log(current.value);
        }
    }

    printQueue(){
        let queue = new Queue(this.root);
        while( queue._first != null){
            let current = queue.dequeue();
            if(current.left != null){
                queue.enqueue(current.left);
            }
            if(current.right != null){
                queue.enqueue(current.right);
            }
            console.log(current.value);
        }
    }

    
}