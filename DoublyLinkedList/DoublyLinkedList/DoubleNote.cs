using System.Runtime.Versioning;

namespace DoublyLinkedList
{
    public class DoubleNote<T>
    {
        public DoubleNote(T data)
        {
            Data = data;
            Prev = null;
            Next = null;
        }

        public DoubleNote<T>? Prev { get; set; }
        public T Data { get; set; }
        public DoubleNote<T>? Next { get; set; }
    }
}
