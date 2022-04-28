using System;
using System.Collections.Generic;
using System.Linq;

namespace Templates
{
    public class Queue<T>
    {
        private List<T> _items = new List<T>();
        public int Count => _items.Count;
        public void Enqueue(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _items.Add(item);
        }
        public T Dequeue()
        {
            var item = GetItem();
            _items.Remove(item);
            return item;
        }
        public T Peek()
        {
            var item = GetItem();
            return item;
        }
        private T GetItem()
        {
            var item = _items.FirstOrDefault();
            if (Count == 0) throw new NullReferenceException("Очередь пуста. Нет элементов для получения.");
            return item;
        }
    }
}
