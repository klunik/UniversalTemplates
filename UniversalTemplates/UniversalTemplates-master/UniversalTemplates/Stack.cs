using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniversalTemplates
{
    public class Stack<T>
    {
        private List<T> ItemsList = new List<T>();
        public int Count => ItemsList.Count;
        public void Push(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            this.ItemsList.Add(item);
        }
        public T Pop()
        {
            var item = this.ItemsList.LastOrDefault();
            if (item == null)
            {
                throw new NullReferenceException("Stack is empty. There is no elements to get.");
            }
            this.ItemsList.RemoveAt(this.ItemsList.Count - 1);
            return item;
        }
        public T Peek()
        {
            var item = this.ItemsList.LastOrDefault();
            if (item == null)
            {
                throw new NullReferenceException("Stack is empty. There is no elements to get.");
            }
            return item;
        }
    }
}
