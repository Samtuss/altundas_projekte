                    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinäreSuchbäumeTraversierung
{
    public class BinaryTree
    {
        private Node _root;
        public void Insert(int value)
        {
            _root = InsertRecursive(_root, value);
        }
        public Node InsertRecursive(Node node, int value)
        {
            if (node == null)
                return new Node(value);

            if (value < node.Value)
                node.Left = InsertRecursive(node.Left, value);
            else if (value > node.Value)
                node.Right = InsertRecursive(node.Right, value);

            return node;
        }
        public void PrintInOrder()
        {
            InOrderRecursive(_root);
            Console.WriteLine();
        }
        private void InOrderRecursive(Node node)
        {
            if (node == null) return;

            InOrderRecursive(node.Left);

            Console.WriteLine($"Aktueller Wert: {node.Value}");
                
            InOrderRecursive(node.Right);
        }

        public void PrintPreOrder()
        {
            PreOrderRecursive(_root);
            Console.WriteLine();
        }
        private void PreOrderRecursive(Node node)
        {
            if (node == null) return;

            Console.WriteLine($"Aktueller Wert: {node.Value}");

            PreOrderRecursive(node.Left);

            PreOrderRecursive(node.Right);

        }

        public void PrintPostOrder()
        {
            PostOrderRecursive(_root);
            Console.WriteLine();
        }
        private void PostOrderRecursive(Node node)
        {
            if (node == null) return;

            PreOrderRecursive(node.Left);

            PreOrderRecursive(node.Right);

            Console.WriteLine($"Aktueller Wert: {node.Value}");
        }

        public void Contains(int value)
        {
            Console.WriteLine(ContainsRecursive(_root, value));
        }
        private bool ContainsRecursive(Node node, int value) // bissi problematisch
        {
            if (node == null) return false;
            if (value == node.Value) return true;

            if (value < node.Value)
                InsertRecursive(node.Left, value);
            else if (value > node.Value)
                InsertRecursive(node.Right, value);

            return true;
        }
    }
}
