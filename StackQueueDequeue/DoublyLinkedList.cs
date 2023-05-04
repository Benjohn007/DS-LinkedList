using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueueDeque
{
    public class DoublyLinkedList<T> : ICollection
    {
        public DoublyLinkedListNode<T>? Head
        {
            get;
            private set;
        }
        public DoublyLinkedListNode<T>? Tail
        {
            get;
            private set;
        }

        int ICollection.Count => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public int Count;

        public void AddHead(T value)
        {
            DoublyLinkedListNode<T> adding = new 
                DoublyLinkedListNode<T>(value);

            if(Head != null)
            {
                Head.Previous = adding;
            }
            Head = adding;
            if(Tail == null)
            {
                Tail = Head;
            }
            Count++;
        }
        public void AddTail(T value)
        {
            DoublyLinkedListNode<T> adding = new
               DoublyLinkedListNode<T>(value);

            if(Tail == null)
            {
                AddHead(value);
            }
            else
            {
                Tail.Next = adding;
                Tail = adding;

                Count++;
            }
        }

        private DoublyLinkedListNode<T> Find(T value)
        {
            DoublyLinkedListNode<T>? current = Head;

            while(current != null)
            {
                if(current.Value.Equals(value)) return current;

                current = current.Next;
            }

            return null;
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }
        
        public bool Remove(T item)
        {
            DoublyLinkedListNode<T> found = Find(item);
            if(found == null)
            {
                return false;
            }

            DoublyLinkedListNode<T> previous = found.Previous;
            DoublyLinkedListNode<T> next = found.Next;

            if(previous == null)
            {
                Head = next;
                if(Head != null)
                {
                    Head.Previous = null;
                }
                else
                {
                    previous.Next = next;
                }

                if(next == null)
                {
                    Tail = previous;
                    if(Tail != null)
                    {
                        //removing the tail
                        Tail.Next = null;
                    }
                    else
                    {
                        next.Previous = previous;
                    }
                }
            }
            Count--;

            return true;
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = Head;
            while(current != null)
            {
                yield return current.Value; 
                current = current.Next;
            }
        }

        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public System.Collections.Generic.IEnumerator<T> GetReverseEnumerator()
        {
            DoublyLinkedListNode<T> current = Tail;
            while (current != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
    }
}
