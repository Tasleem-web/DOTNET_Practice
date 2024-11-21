using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;
            public Node Prev;

            public Node(T data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }

        private Node head;
        private Node tail;
        private int count;

        public int Length => count;

        public void Add(T e)
        {
            Node newNode = new Node(e);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            count++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException("index");
            Node newNode = new Node(e);
            if (index == 0)
            {

                if (head == null)
                {
                    head = tail = newNode;
                }
                else
                {
                    newNode.Next = head;
                    head.Prev = newNode;
                    head = newNode;
                }
            }
            else if (index == count)
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current;
                newNode.Prev = current.Prev;
                current.Prev.Next = newNode;
                current.Prev = newNode;
            }
            count++;
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Remove(T item)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                    else
                    {
                        tail = current.Prev;
                    }

                    count--;
                    return;
                }
                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current.Prev != null)
            {
                current.Prev.Next = current.Next;
            }
            else
            {
                head = current.Next;
            }

            if (current.Next != null)
            {
                current.Next.Prev = current.Prev;
            }
            else
            {
                tail = current.Prev;
            }

            count--;
            return current.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
