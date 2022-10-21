using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED2
{
    internal class Node
    {
        public int num;
        public Node ses = null!;
        public Node sdi = null!;



        public Node(int num)
        {
            this.num = num;

        }
        public void Add(int key)
        {
            if (key < num)
            {
                if (ses != null)
                {
                    ses.Add(key);
                }
                else
                {
                    ses = new Node(key);
                }
            }
            else
            {
                if (sdi != null)
                {
                    sdi.Add(key);
                }
                else
                {
                    sdi = new Node(key);
                }
            }
        }

        public Node Remove(int key)
        {

            if (key == num)
            {
                if (ses == null & sdi == null)
                {
                    return null;
                }
                if (ses == null)
                {
                    return sdi;
                }
                if (sdi == null)
                {
                    return ses;
                }
                Node h = ses;
                while (h.sdi != null)
                {
                    h = h.sdi;
                }
                int aux = h.num;
                Remove(h.num);
                num = aux;
                return this;
            }
            if (key < num)
            {
                if (ses != null)
                    ses = ses.Remove(key);


            }
            else if (key > num)
            {
                if (sdi != null)
                    sdi = sdi.Remove(key);

            }
            return this;

        }
        public Node Find(int key)
        {
            if (key < num)
            {
                if (ses != null)
                    return ses.Find(key);
                else
                {
                    Node node = new Node(-1);
                    return node;
                }

            }
            else if (key > num)
            {
                if (sdi != null)
                    return sdi.Find(key);
                else
                {
                    Node node = new Node(-1);
                    return node;
                }

            }
            else
            {
                return this;
            }
        }


        public int Altura()
        {
            if (ses == null && sdi == null)
            {
                return 0;
            }
            else if (ses != null && sdi != null)
            {
                return 1 + Math.Max(ses.Altura(), sdi.Altura());
            }
            else if (ses == null && sdi != null) { return 1 + Math.Max(-1, sdi.Altura()); }
            else if (ses != null && sdi == null) { return 1 + Math.Max(ses.Altura(), -1); }
            else
            {
                return -1;
            }
        }
        //Print por camadas

        public void PrintP(List<(int count, Node node)> nodes, int count)
        {
            bool v = false;
            nodes.Add((count, this));

            if (ses != null)
            {
                count++; 
                ses.PrintP(nodes, count);
                v = true;

            }
            if (sdi != null)
            {
                count++;
                if (v)
                    count--;
                 
                sdi.PrintP(nodes, count);
            }
        }

        public void Print()
        {
            var nodes = new List<(int count,Node node)>(); 
            int count = 0;

            PrintP(nodes,count);

            for (int j = 0; j <= Altura(); j++)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i].count == j)
                    {

                        Console.Write("<");
                        Console.Write(nodes[i].node.num);
                        Console.Write(">");

                    }
                }
                Console.WriteLine();
            }
        }


    }
}
