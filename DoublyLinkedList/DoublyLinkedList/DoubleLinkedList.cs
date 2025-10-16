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

        public string GetForward()
        {
            var output = string.Empty;
            var current = _head;
            while (current != null)
            {
                output += $"{current.Data} <=> ";
                current = current.Next;
            }
            return output.Substring(0, output.Length - 5);
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

        public void ReverseOrder()
        {
            DoubleNote<T> prev = null!;
            DoubleNote<T> current = _head!;
            DoubleNote<T> next = null!;
            while(current != null)
            {
                next = current.Next!;
                current.Next = prev;
                prev = current;
                current = next;
            }
            _head = prev;
        }

        public string GetMode()
        {
            if (_head == null)
            {
                return "List empty";
            }
            var current = _head;
            var frequency = new Dictionary<T, int>();
            while (current != null)
            {
                if (frequency.ContainsKey(current.Data))
                {
                    frequency[current.Data]++;
                }
                else
                {
                    frequency[current.Data] = 1;
                }
                current = current.Next;
            }
            int maxCount = frequency.Values.Max();
            var modes = frequency.Where(x => x.Value == maxCount).Select(x => x.Key).ToList();

            if (modes.Count > 1)
            {
                return $"Mode(s): {string.Join(", ", modes)}";
            }
            else
            {
                return $"Mode(s): {modes[0]}";
            }
        }

        public void Graph()
        {
            if (_head == null)
            {
                return;
            }
            
            var graph = new Dictionary<T, int>();
            DoubleNote<T> current = _head;

            while (current != null)
            {
                if (graph.ContainsKey(current.Data))
                {
                    graph[current.Data]++;
                }
                else
                {
                    graph[current.Data] = 1;
                }
                current = current.Next!;
            }

            foreach (var pair in graph.OrderBy(p => p.Key))
            {
                Console.Write($"{pair.Key} {new string('*', pair.Value)} \n");
            }
        }

        public string GetContains(T data)
        {
            DoubleNote<T> current = _head!;
            while (current != null)
            {
                if (current.Data!.Equals(data))
                {
                    return $"If it exists";
                }
                current = current.Next!;
            }
            return $"It does not exist {data}";
        }

        public void Remove()
        {
            if (_head == null)
            {
                return;
            }

            if (_head.Next == null)
            {
                _head = null;
                _tail = null;
                return;
            }
            _head = _head.Next;
            _head.Prev = null;
        }

        public void RemoveAll(T data)
        {
            if (_head == null)
            {
                return;
            }

            DoubleNote<T> current = _head!;
            bool item = false;

            while (current != null)
            {
                var nextNode = current.Next;

                if (current.Data!.Equals(data))
                {
                    item = true;

                    if (current.Prev == null)
                    {
                        _head = current.Next;

                        if (_head != null)
                        {
                            _head.Prev = null;
                        }
                    }
                    else if (current.Next == null)
                    {
                        _tail = current.Prev;
                        _tail!.Next = null;
                    }
                    else
                    {
                        current.Prev!.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                }
                current = nextNode!;
            }
        }   
    }
}
