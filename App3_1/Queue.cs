using System.Collections;

namespace App3_1
{
    class Queue : ArrayList
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