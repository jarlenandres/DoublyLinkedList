using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    public class DoubleLinkedList<T>
    {
        private DoubleNote<T>? _head;
        private DoubleNote<T>? _tail;

        public DoubleLinkedList()
        {
            _tail = null;
            _head = null;
        }

        public void InsertItem(T data)
        {
            var newNode = new DoubleNote<T>(data);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
            }
            var current = _head;
            while (current != null)
            {
                var index = current.Next;
                while (index != null)
                {
                    if (Comparer<T>.Default.Compare(current.Data, index.Data) > 0)
                    {
                        var temp = current.Data;
                        current.Data = index.Data;
                        index.Data = temp;
                    }
                    index = index.Next;
                }
                current = current.Next;
            }
        }

        public string GetBackward()
        {
            var output = string.Empty;
            var current = _tail;
            while (current != null)
            {
                output += $"{current.Data} <=> ";
                current = current.Prev;
            }
            return output.Substring(0, output.Length - 5);
        }
    }
}
