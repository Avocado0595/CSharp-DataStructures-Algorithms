using System;
using System.Collections.Generic;


namespace ConsoleApplication01
{
    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;
        public void ShowNode()
        {
            Console.Write(Data+" ");
        }
    }

    public class BinarySearchTree
    {
        public Node root;
        public BinarySearchTree()
        {
            root = null;
        }
        public void Insert(int i)
        {
            Node newNode = new Node();
            newNode.Data = i;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parrent;
                while(true)
                {
                    parrent = current;
                    if (i<current.Data)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parrent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parrent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public void inOrder(Node theRoot)
        {
            if (!(theRoot == null))
            {
                inOrder(theRoot.Left);
                theRoot.ShowNode();
                inOrder(theRoot.Right);
            }
        }

        public void preOrder(Node theRoot)
        {
            if (!(theRoot == null))
            {
                theRoot.ShowNode();
                preOrder(theRoot.Left);
                preOrder(theRoot.Right);
            }
        }

        public void postOrder(Node theRoot)
        {
            if (!(theRoot == null))
            {
                postOrder(theRoot.Left);
                postOrder(theRoot.Right);
                theRoot.ShowNode();
            }
        }
        public int findMax()
        {
            Node current = root;
            while(current.Right != null)
            {
                current = current.Right;
            }
            return current.Data;
        }

        public int findMin()
        {
            Node current = root;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current.Data;
        }

        public Node findNode(int i)
        {
            Node current = root;
            while(current.Data != i && current != null)
            {
                if (current.Data > i)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            return current;
        }

        public bool isContain(int i)
        {
            bool result = false;
            Node find = findNode(i);
            if (find != null)
                result = true;
            return result;
        }

        public Node GetSuccessor(Node delNode)
        {
            Node successorParent = delNode;
            Node successor = delNode;
            Node current = delNode.Right;
            while (!(current == null))
            {
                successorParent = successor;
                successor = current;
                current = current.Left;
            }
            if (!(successor == delNode.Right))
            {
                successorParent.Left = successor.Right;
                successor.Left = delNode.Left;
                successor.Right = successorParent;
            }
            return successor;
        }

        public void Delete(int key)
        {
            Node current = root;
            Node parent = root;
            bool isLeftChild = true;

            while(current.Data != key)
            {
                parent = current;
                if (current.Data > key)
                {
                    current = current.Left;
                    isLeftChild = true;
                }
                else
                {
                    current = current.Right;
                    isLeftChild = false;
                }
                if (current == null)
                    return;
            }

            if (current.Left == null && current.Right == null)
            {
                if (current == root)
                    root = null;
                else
                {
                    if (isLeftChild)
                        parent.Left = null;
                    else
                        parent.Right = null;
                }
            }
            else
            {
                if (current.Left == null)
                {
                    if (current == root)
                        root = current.Right;
                    else
                    {
                        if (isLeftChild)
                            parent.Left = current.Right;
                        else
                            parent.Right = current.Right;
                    }
                }
                else
                    if (current.Right == null)
                {
                    if (current == root)
                        root = current.Left;
                    else
                    {
                        if (isLeftChild)
                            parent.Left = current.Left;
                        else
                            parent.Right = current.Left;
                    }
                }
                else
                {
                    Node successor = GetSuccessor(current);
                    if (current == root)
                        root = successor;
                    else if (isLeftChild)
                        parent.Left = successor;
                    else
                        parent.Right = successor;
                        successor.Left = current.Left;
                }
            }
        }
    }
  
    class Program
    {
        

        static void Main(string[] args)
        {
            BinarySearchTree nums = new BinarySearchTree();
            nums.Insert(23);
            nums.Insert(45);
            nums.Insert(16);
            nums.Insert(37);
            nums.Insert(3);
            nums.Insert(99);
            nums.Insert(80);
            nums.Insert(22);
            nums.Insert(24);
            nums.Insert(120);
            nums.Insert(100);
            nums.Insert(105);
            nums.Insert(102);
            nums.Insert(131);
            nums.Insert(140);
            Console.WriteLine("Inorder traversal: ");
            nums.inOrder(nums.root);
            Console.WriteLine();
            Console.WriteLine("23 in tree: {0}", nums.isContain(23));
            nums.Delete(45);
            nums.inOrder(nums.root);

            Console.ReadKey();

        }
    }
}
