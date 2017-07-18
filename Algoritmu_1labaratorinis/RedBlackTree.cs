using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmu_1labaratorinis
{
    public enum Color
    {
        Red = 0, Black = 1
    }

    public enum Direction
    {
        Left, Right
    }

    public sealed class RedBlackTree : Tree
    {
        private Color Black = Color.Black;
        private Color Red = Color.Red;

        private Node parentNode;
        private Node grandParentNode;
        private Node tempNode;

        public RedBlackTree()
        {
        }

        public void Insert(IComparable item)
        {
            currentNode = parentNode = grandParentNode = root;
            freshNode.data = item;

            int returnedValue = 0;
            while (Compare(item, currentNode) != 0)
            {
                tempNode = grandParentNode;
                grandParentNode = parentNode;
                parentNode = currentNode;

                returnedValue = Compare(item, currentNode);

                if (returnedValue < 0)
                    currentNode = currentNode.left;
                else
                    currentNode = currentNode.right;

                if (currentNode.left.color == Color.Red &&
                   currentNode.right.color == Color.Red)
                    ReArrange(item);
            }

            if (currentNode == freshNode)
            {
                currentNode = new Node(item, freshNode, freshNode);

                if (Compare(item, parentNode) < 0)
                    parentNode.left = currentNode;
                else
                    parentNode.right = currentNode;

                ReArrange(item);
            }
        }

        private void ReArrange(IComparable item)
        {
            currentNode.color = Red;
            currentNode.left.color = Color.Black;
            currentNode.right.color = Color.Black;

            if (parentNode.color == Color.Red)
            {
                grandParentNode.color = Color.Red;

                bool compareWithGrandParentNode = (Compare(
                   item, grandParentNode) < 0);
                bool compareWithParentNode = (Compare(
                   item, parentNode) < 0);

                if (compareWithGrandParentNode != compareWithParentNode)
                    parentNode = Rotate(item, grandParentNode);

                currentNode = Rotate(item, tempNode);
                currentNode.color = Black;
            }

            root.right.color = Color.Black;
        }


        private Node Rotate(IComparable item, Node parentNode)
        {
            int value;

            if (Compare(item, parentNode) < 0)
            {
                value = Compare(item, parentNode.left);
                if (value < 0)
                    parentNode.left = this.Rotate(
                    parentNode.left, Direction.Left);
                else
                    parentNode.left = this.Rotate(
                    parentNode.left, Direction.Right);
                return parentNode.left;
            }
            else
            {
                value = Compare(item, parentNode.right);

                if (value < 0)
                    parentNode.right = this.Rotate(
                    parentNode.right, Direction.Left);
                else
                    parentNode.right = this.Rotate(
                    parentNode.right, Direction.Right);
                return parentNode.right;
            }
        }

        private Node Rotate(Node node, Direction direction)
        {
            Node tempNode;

            if (direction == Direction.Left)
            {
                tempNode = node.left;
                node.left = tempNode.right;
                tempNode.right = node;
                return tempNode;
            }
            else
            {
                tempNode = node.right;
                node.right = tempNode.left;
                tempNode.left = node;
                return tempNode;
            }
        }
    }
}
