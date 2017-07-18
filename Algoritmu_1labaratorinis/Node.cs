using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmu_1labaratorinis
{
    public class Node
    {
        public IComparable data;
        public Node left;
        public Node right;
        public Color color = Color.Black;

        public Node(IComparable data)
           : this(data, null, null)
        {
        }

        public Node(IComparable data, Node left, Node right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
    }
}
