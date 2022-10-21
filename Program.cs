using System;

namespace ED2
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(10);
            root.Add(5);
            root.Add(3);
            root.Add(1);
            root.Add(6);
            root.Add(15);
            root.Add(12);
            root.Add(13);
            root.Add(25);
            root.Add(17);
            root.Add(30);
            root.Print();
            root.Remove(5);
            Console.WriteLine("#########################################");
            root.Print();
            root.Remove(10);
            Console.WriteLine("#########################################");
            root.Print();



        }
    }
}