namespace Exercise_10
{
    public class ParentStack
    {
        Node head;

        public void Push(BracketType bracketType)
        {
            Node newNode = new Node(bracketType);

            if (head is null)
            {
                head = newNode;
                return;
            }

            newNode.Next = head;
            head = newNode;
        }

        public BracketType Pop()
        {
            if (Empty())
                return BracketType.Default;

            BracketType popedData = head.Data;

            head = head.Next;

            return popedData;
        }

        public BracketType Peek()
        {
            return head.Data;
        }

        public bool Empty()
        {
            return head is null;
        }
    }

    class Node
    {
        public BracketType Data { get; set; }

        public Node Next { get; set; }

        public Node(BracketType bracketType)
        {
            this.Data = bracketType;
        }

        public Node(BracketType bracketType, Node next) : this(bracketType)
        {
            Next = next;
        }
    }

    public enum BracketType
    {
        LeftSquare = '[', RightSquare = ']',
        LeftCurly = '{', RightCurly = '}',
        LeftRound = '(', RightRound = ')',
        LeftAngle = '<', RightAngle = '>',
        Default
    }
}
