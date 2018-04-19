using System.Collections.Generic;

namespace App3_3
{
    public class Queue : List<object>
    {
        public void Enqueue(object value)
        {
            Add(value);
        }

        public object Dequeue()
        {
            var last = this[Count - 1];
            RemoveAt(Count - 1);
            return last;
        }
    }
}