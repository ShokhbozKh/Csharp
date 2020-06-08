using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_10
{
    class Node
    {
        private Type t;
        private Node next;

        public Node(Type t)
        {
            SetType(t);
            this.next = null;
        }

        private void SetType(Type t)
        {
            this.t = t;
        }

        public Type GetMyType()
        {
            return this.t;
        }

        public void SetNext(Node next)
        {
            this.next = next;
        }

        public Node GetNext()
        {
            return this.next;
        }
    }

    enum Type
    {
        curlyOpen = '{', curlyClose = '}',
        squareOpen = '[', squareClose = ']',
        roundOpen = '(', roundClose = ')',
        none = '0'
    }
}
