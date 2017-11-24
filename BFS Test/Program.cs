using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_Test
{
    public class Node
    {
        public int data;
        public Node next;
    }

    public class Queue
    {
        public Node front;
        public Node rear;

        public Queue()
        {
            front = null;
            rear = null;
        }

        public void enQueue(TreeNode node)
        {
            Node temp = new Node();

            temp.data = node.data;
            temp.next = null;

            if (front == null)
            {
                front = temp;
            }

            else
            {
                rear.next = temp;
            }

            rear = temp;
        }

        public TreeNode deQueue()
        {
            Node temp = new Node();

            TreeNode value = new TreeNode();

            if (front == null)
            {
                Console.WriteLine("front is empty.");
                return null;
            }

            else
            {
                front = front.next;
                temp = front;
                value.data = temp.data;
                temp = null;
                return value;
            }

        }

        public bool isEmpty()
        {
            return (front == null);
        }

        public void display()
        {
            Node p = new Node();

            p = front;

            if (front == null)
            {
                Console.WriteLine("Nothing to display.");
            }

            else
            {
                while (p != null)
                {
                    Console.WriteLine(p.data);
                    p = p.next;
                }
            }
        }


        public class TreeNode
        {
            public int data;

            public TreeNode LeftNode;
            public TreeNode RightNode;

            public int getData()
            {
                return data;
            }

            public void setData(int data)
            {
                this.data = data;
            }

            public void setLeftNode(TreeNode next)
            {
                this.LeftNode = next;
            }
            
            public void setRightNode(TreeNode next)
            {
                this.RightNode = next;
            }

            public TreeNode getLeftNode()
            {
                return this.LeftNode;
            }

            public TreeNode getRightNode()
            {
                return this.RightNode;
            }

            public void BFS()
            {
                Queue Q = new Queue();
                TreeNode temp = new TreeNode();
                temp = this;

                Q.enQueue(temp);

                while (temp != null)
                {
                    if (temp.LeftNode != null)
                    {
                        Q.enQueue(temp.LeftNode);
                    }

                    if (temp.RightNode != null)
                    {
                        Q.enQueue(temp.RightNode);
                    }

                    Console.WriteLine("{0}", temp.data);
                    temp = Q.deQueue();

                }

            }


        }

    

 
             


        
        class Program
        {
            static void Main(string[] args)
            {

                TreeNode[] BTree = new TreeNode[9];
               
                   for (int i = 0; i < 9; i++)
                    BTree[i] = new TreeNode();
                
               BTree[0].setData(0);
               BTree[1].setData(1);
               BTree[2].setData(2);
               BTree[3].setData(3);
               BTree[4].setData(4);
               BTree[5].setData(5);
               BTree[6].setData(6);
               BTree[7].setData(7);
               BTree[8].setData(8);
               
               BTree[0].setLeftNode(BTree[1]);
               BTree[0].setRightNode(BTree[2]);
               BTree[1].setLeftNode(BTree[3]);
               BTree[1].setRightNode(BTree[4]);
               BTree[2].setRightNode(BTree[5]);
               BTree[2].setLeftNode(BTree[6]);
               BTree[3].setLeftNode(BTree[7]);
               BTree[7].setRightNode(BTree[8]);
               
               BTree[0].BFS();

            }

        }
    }
}
