using System;

namespace UniversalTemplates
{   
    public class Queue<T>
    {
        private int Head = -1, Rear = -1, Count = 0;
        private readonly int Size;
        private readonly T[] Array;
        public Queue(int Size)
        {
            this.Size = Size;
            this.Array = new T[Size];
        }
        public bool IsFull()
        {
            return this.Rear == this.Size - 1;
        }
        public bool IsEmpty()
        {
            return this.Count == 0;
        }
        public void AddOne(T Item)
        {
            if (this.IsFull())
                throw new Exception("List is full.");
            this.Array[++this.Rear] = Item;
            this.Count++;
        }
        public T GetTheList()
        {
            if (this.IsEmpty())
                throw new Exception("List is not full.");
            T value = this.Array[++this.Head];
            this.Count--;
            if (this.Head == this.Rear)
            {
                this.Head = -1;
                this.Rear = -1;
            }
            return value;
        }
    }
}
