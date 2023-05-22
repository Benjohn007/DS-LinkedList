using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SortedLinkedListNode<T>
    {
        public T data { get; set; }
        public SortedLinkedListNode<T> Next { get; set; }
        public SortedLinkedListNode<T> Prev { get; set; }
        public SortedLinkedListNode(T value) 
        {
            data = value;
        }
    }
    public class SortedLinkedList<T>
    {
        public SortedLinkedListNode<T> Head;
        public SortedLinkedListNode<T> Tail;

        public int Count { get; private set; }

        public void Add(T value)
        {
            SortedLinkedListNode<T> node = new(value);
            if (Head == null)
            {
                Head = node;
                Tail = Head;
            }
            else if(Head.data.Equals(value).CompareTo(value) >= 0) 
            {
                SortedLinkedListNode<T> newHead = new(value);
                newHead.Next = Head;
                Head.Prev = newHead;
                Head = newHead;
            }
            else if(Tail.data.Equals(value).CompareTo(value) < 0)
            {
                SortedLinkedListNode<T> newTail = new(value);
                newTail.Prev = Tail;
                Tail.Next = newTail;
                Tail = newTail;
            }
            else
            {
                SortedLinkedListNode<T> insertBefore = Head;
                while(insertBefore.data.Equals(value).CompareTo(value) <0) 
                {
                    insertBefore = insertBefore.Next;
                }

                SortedLinkedListNode<T> toInsert = new(value);
                toInsert.Next = insertBefore;
                toInsert.Prev = insertBefore.Prev;
                insertBefore.Prev.Next = toInsert;
                insertBefore.Prev = toInsert;
            }
            Count++;
        }
    }
}
