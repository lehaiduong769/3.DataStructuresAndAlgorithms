using System;

namespace BT1
{
    class Program
    {
        public static Node head = null;
        static void Main(string[] args)
        {
            LinkedList llist = new LinkedList();
            MainMenu(llist);
        }
        
        static void CreatedList()
        {
            int num;
            Console.Write($"Nhap vao so phan tu trong danh sach: ");
            num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                InsertTail();
            }
           
        }
        static void Traversing(LinkedList llist)
        {
            Node p = head;
            while (p != null)
            {
                Console.Write(p.data + " -> ");
                llist.push(p.data);
                p = p.Next;
            }
            Console.WriteLine("NULL");
        }
        static void InsertHead()
        {
            int x;
            Console.Write("Nhap vao x: ");
            x = int.Parse(Console.ReadLine());
            Node n = new Node(x);
            
            if (head == null)
                head = n;
            else
            {
                n.Next = head;
                head = n;
            }
        }
        static void InsertTail()
        {
            int x;
            Console.Write("Nhap vao x: ");
            x = int.Parse(Console.ReadLine());
            Node n = new Node(x);
            Node p = null;
            if (head == null) head = n;
            else
            {
                p = head;
                while (p.Next != null)
                {
                    p = p.Next;
                }

                p.Next = n;
            }
        }
        public static bool Search(Node head)
        {
            int x;
            Console.Write("Input data searched: ");
            x = int.Parse(Console.ReadLine());
            Node current = head; // Initialize current
            while (current != null)
            {
                if (current.data == x)
                    return true; // data found
                current = current.Next;
            }
            return false; // data not found
        }
        static void DeleteHead()
        {
            if (head != null)
            {
                head = head.Next;
            }
          
        }
               
        static void DeleteX()
        {
            int x;
            Console.Write("Nhap vao x: ");
            x = int.Parse(Console.ReadLine());
            Node q = head;
            Node prev = null;
            if (q != null && q.data == x)  
            {
                q = q.Next;
                return;
            }
            while (q!=null && q.data != x)
            {
                prev = q;
                q = q.Next;
            }
            if (q == null)
            {
                return;
            }
            prev.Next = q.Next;

        }
        static int LargestElement(Node head)
        {
            int max = int.MinValue;
            while (head != null)
            {
                if (max < head.data)
                    max = head.data;
                head = head.Next;
            }
            return max;
        }
      
        static int smallestElement(Node head)
        {

            // Declare a min variable and initialize 
            // it with INT_MAX value. 
            // INT_MAX is integer type and its value 
            // is 32767 or greater. 
            int min = int.MaxValue;

            // Check loop while head not equal to NULL 
            while (head != null)
            {

                // If min is greater then head->data then 
                // assign value of head->data to min 
                // otherwise node point to next node. 
                if (min > head.data)
                    min = head.data;

                head = head.Next;
            }
            return min;
        }
        private static void MainMenu(LinkedList llist)
        {
            int choice;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Create Your LinkedList");
                Console.WriteLine("2) Traverse ");
                Console.WriteLine("3) Insert X ");
                Console.WriteLine("4) Remove the 1st node");
                Console.WriteLine("5) Remove X ");
                Console.WriteLine("6) Search X ");
                Console.WriteLine("7) Searching the Max node.data ");
                Console.WriteLine("0) Exit ");
                Console.Write("\r\nSelect an option: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreatedList();
                        Traversing(llist);
                        break;
                    case 2:
                        Traversing(llist);
                        break;
                    case 3:
                        InsertTail();
                        Traversing(llist);
                        break;
                    case 4:
                        DeleteHead();
                        Traversing(llist);
                        break;
                    case 5:
                        DeleteX();
                        Traversing(llist);
                        break;
                    case 6:
                        if (Search(head))
                            Console.WriteLine("Yes");
                        else
                            Console.WriteLine("No");
                        break;
                    case 7:
                        Console.WriteLine($"Gia tri lon nhat trong ds la: {LargestElement(head)} ");
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("vui long nhap lai");
                        break;
                }
             
            }
            while (choice != 0);

        }
    }
}
