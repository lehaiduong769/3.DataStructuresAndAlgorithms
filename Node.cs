using System;
using System.Collections.Generic;
using System.Text;

namespace BT1
{
    class Node
    {
        public int data;
        public Node Next;
        public Node(int d)
        {
            data = d;
            Next = null;
        }
        public Node()
        {
            data = default;
            Next = null;
        }
    }
}
