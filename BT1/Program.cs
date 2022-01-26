using System;

namespace BT1
{
    class Program
    {
        public static Node root = null;
        static void Main(string[] args)
        {
            Insert(ref root, 5);
            Insert(ref root, 3);
            Insert(ref root, 7);
            Insert(ref root, 9);
            Insert(ref root, 8);
            Insert(ref root, 11);
            Insert(ref root, 6);
            Insert(ref root, 20);
            Insert(ref root, 19);
            Insert(ref root, 37);
            Insert(ref root, 25);
            Insert(ref root, 21);
            Insert(ref root, 15);
            Insert(ref root, 12);
            Console.Write("Duyet LRN: ");
            LRN(root);
            Console.WriteLine();
            Console.Write("Duyet LNR: ");
            LNR(root);
            Console.WriteLine();
            Console.Write("Cac la cua cay: ");
            printLeafNodes(root);
            Console.WriteLine();
            Console.WriteLine("Chieu cao cua cay: {0}",Height(root));
            Delete(root, 21);
            Console.Write("Duyet lai LRN sau khi xoa 21: ");
            LRN(root);
            Console.WriteLine();
        }
        static Node Insert(ref Node root, int key)
        {
            if(root == null)
            {
                root = new Node(key);
                return root;
            }
            if (key<root.data)
            {
                root.left = Insert(ref root.left, key);
            }
            else if (key>root.data)
            {
                root.right = Insert(ref root.right, key);
            }
            return root;
        }
        static void LRN(Node root)
        {
            if (root != null)
            {   
                LRN(root.left);
                LRN(root.right);
                Console.Write(root.data + " ");
            }
        }
        static void LNR(Node root)
        {
            if (root != null)
            {
                LNR(root.left);
                Console.Write(root.data + " ");
                LNR(root.right);
            }
        }
        static void printLeafNodes(Node root)
        {

            // If node is null, return
            if (root == null)
                return;

            // If node is leaf node, print its data    
            if (root.left == null &&
                root.right == null)
            {
                Console.Write(root.data + " ");
                return;
            }

            // If left child exists, check for leaf
            // recursively
            if (root.left != null)
                printLeafNodes(root.left);

            // If right child exists, check for leaf
            // recursively
            if (root.right != null)
                printLeafNodes(root.right);
        }
        static int Height(Node node)
        {
            if (node == null)
                return -1;
            else
            {
                /* compute the depth of each subtree */
                int lDepth = Height(node.left);
                int rDepth = Height(node.right);

                /* use the larger one */
                if (lDepth > rDepth)
                    return (lDepth + 1);
                else
                    return (rDepth + 1);
            }
        }
        static Node Delete(Node root, int key)
        {
            if (root == null) return root;
            if (key < root.data)
                root.left = Delete(root.left, key);
            else if (key > root.data)
                root.right = Delete(root.right, key);
            else// node with only one child or no child 
            {
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;
                // node with two children: find smallest  in the right subtree) 
                else
                {
                    root.data = minValue(root.right);
                    // Delete the replacement node
                    root.right = Delete(root.right, root.data);
                }
            }
            return root;
        }
        static int minValue(Node root)
        {
            int minv = root.data;
            while (root.left != null)
            {
                minv = root.left.data;
                root = root.left;
            }
            return minv;
        }
    }
}
