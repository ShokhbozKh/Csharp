using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_10
{
    class ParenStack
    {
        private Node head;

        public void Push(Type newTop)
        {
            Node newNode = new Node(newTop);
            newNode.SetNext(this.head);
            this.head = newNode;
        }

        public Type Pop()
        {
            Type deletedValue = this.head.GetMyType();

            this.head = this.head.GetNext();

            return deletedValue;
        }

        public bool Empty()
        {
            return this.head == null;
        }
    }

    
}
