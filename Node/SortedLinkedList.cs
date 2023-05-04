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
        public SortedLinkedListNode<T> next { get; set; }
        public SortedLinkedListNode<T> prev { get; set; }
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
                newHead.next = Head;
                Head.prev = newHead;
                Head = newHead;
            }
            else if(Tail.data.Equals(value).CompareTo(value) < 0)
            {
                SortedLinkedListNode<T> newTail = new(value);
                newTail.prev = Tail;
                Tail.next = newTail;
                Tail = newTail;
            }
            else
            {
                SortedLinkedListNode<T> insertBefore = Head;
                while(insertBefore.data.Equals(value).CompareTo(value) <0) 
                {
                    insertBefore = insertBefore.next;
                }

                SortedLinkedListNode<T> toInsert = new(value);
                toInsert.next = insertBefore;
                toInsert.prev = insertBefore.prev;
                insertBefore.prev.next = toInsert;
                insertBefore.prev = toInsert;
            }
            Count++;
        }
    }
}
