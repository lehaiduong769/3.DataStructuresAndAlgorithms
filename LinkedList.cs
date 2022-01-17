using System;
using System.Collections.Generic;
using System.Text;

namespace BT1
{
    class LinkedList
    {
        Node head;

        // Inserts a new node at the front of the list
        public void push(int new_data)
        {
            // Allocate new node and putting data
            Node new_node = new Node(new_data);

            // Make next of new node as head
            new_node.Next = head;

            // Move the head to point to new Node
            head = new_node;
        }
    }
}
