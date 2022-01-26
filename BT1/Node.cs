using System;
using System.Collections.Generic;
using System.Text;

namespace BT1
{
    class Node
    {
        public int data;
        public Node left;
        public Node right;
        public Node(int d)
        {
            data = d;
            left = right = null;
        }
    }
}
