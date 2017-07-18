using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmu_1labaratorinis
{
    public class Tree
    {
        public Node root;
        protected Node freshNode;
        protected Node currentNode;

        protected Tree()
        {
            freshNode = new Node(null);
            freshNode.left = freshNode.right = freshNode;
            root = new Node(null);
            root.left = freshNode;
            root.right = freshNode;
        }

        protected int Compare(IComparable item, Node node)
        {
            if (node != root)
                return item.CompareTo(node.data);
            else
                return 1;
        }

        public IComparable Search(IComparable data)
        {
            freshNode.data = data;
            currentNode = root.right;

            while (true)
            {
                if (Compare(data, currentNode) < 0)
                    currentNode = currentNode.left;
                else if (Compare(data, currentNode) > 0)
                    currentNode = currentNode.right;
                else if (currentNode != freshNode)
                    return currentNode.data;
                else
                    return "Does not exist";
            }
        }


        public void Display()
        {
            this.Display(root.right);
        }

        protected void Display(Node temp)
        {
            if (temp != freshNode)
            {
                Display(temp.left);
                Console.WriteLine(" Data= " + temp.data + ". Color= " + temp.color + ".");
                Display(temp.right);
            }
        }
    }
}
