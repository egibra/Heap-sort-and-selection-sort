using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmu_1labaratorinis
{
    class MyDataList : DataList
    {
        public class MyLinkedListNode
        {
            public MyLinkedListNode nextNode { get; set; }
            public double data { get; set; }
            public MyLinkedListNode(double data)
            {
                this.data = data;
            }
        }
        MyLinkedListNode headNode;
        MyLinkedListNode currentNode;
        MyLinkedListNode pointer;
        MyLinkedListNode prevNode;
        public MyDataList(int n)
        {
            length = n;
            Random rand = new Random();
            headNode = new MyLinkedListNode(rand.Next(0, 10000));
            currentNode = headNode;
            for (int i = 0; i < length; i++)
            {
                var temp = currentNode;
                currentNode.nextNode = new MyLinkedListNode(rand.Next(0,10000));
                currentNode = currentNode.nextNode;
                prevNode = temp;
            }
            currentNode.nextNode = null;
            pointer = headNode;
        }
        public override double this[int index]
        {
            get
            {
                if (index >= 0 && index < length)
                {
                    currentNode = headNode;
                    for (int i = 0; i< index; i++)
                    {
                        currentNode = currentNode.nextNode;
                    }
                }
                return currentNode.data;
            }

            set
            {
                if (index >= 0 && index < length)
                {
                    currentNode = headNode;
                    for (int i = 0; i < index; i++)
                    {
                        currentNode = currentNode.nextNode;
                    }
                    currentNode.data = value;
                }
                
            }
           
        }
        public override double Head()
        {
            currentNode = headNode;
            return currentNode.data;
        }
        public override double Next()
        {
            if (currentNode.nextNode == null)
            {
                return -1;
            }
            currentNode = currentNode.nextNode;
            return currentNode.data;
        }
        public override double Previous()
        {
            if (prevNode == null)
            {
                return -1;
            }
            return prevNode.data;
        }
        public override void Swap(double a, double b)
        {
            prevNode.data = a;
            currentNode.data = b;
        }
        public override void Swap()
        {
            var temp = prevNode.data;
            prevNode.data = currentNode.data;
            currentNode.data = temp;
        }

        public override void MovePointerAhead()
        {
            pointer = pointer.nextNode;
        }
        public override bool HasPointerNext()
        {
            return pointer.nextNode != null;
        }
        public override bool HasNext()
        {
            return currentNode.nextNode != null;
        }
        public override bool HasPrevious()
        {
            return prevNode != null;
        }
        public override double PeekPrevious()
        {
            return prevNode.data;
        }
        public override double PeekNext()
        {
            return currentNode.nextNode.data;
        }
        public override double Peek()
        {
            return currentNode.data;
        }
        public override void GoToPointer()
        {
            currentNode = pointer;
        }

        public override void PrintList()
        {
            for (var i = headNode; i.nextNode != null; i = i.nextNode)
            {
                Console.WriteLine(i.data);
            }
        }
        public void selectionSort()
        {
            MyLinkedListNode i, j, min;
            double temp;
            if (headNode != null)
            for (i = headNode; headNode.nextNode != null; i = i.nextNode)
            {
                min = i;
                    if (min.nextNode == null)
                        break;
                for (j = min.nextNode; j != null; j = j.nextNode)
                    if (j.data < min.data)
                    {
                        min = j;
                    }
                temp = min.data;
                min.data = i.data;
                i.data = temp;
            }

        }
    }
}
