namespace BinäreSuchbäumeTraversierung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(4);

            Console.WriteLine($"In Order:");
            tree.PrintInOrder();

            Console.WriteLine();

            Console.WriteLine($"Pre Order:");
            tree.PrintPreOrder();

            Console.WriteLine();

            Console.WriteLine($"Post Order:");
            tree.PrintPostOrder();

            Console.WriteLine();

            tree.Contains(3);
        }
    }
}
