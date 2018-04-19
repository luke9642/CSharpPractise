using System.Collections;

namespace App3_1
{
    public class CorrectQueue
    {
        private ArrayList _arr;

        public CorrectQueue()
        {
            _arr = new ArrayList();
        }
        
        public void Enqueue(object value)
        {
            _arr.Add(value);
        }

        public object Dequeue()
        {
            var last = _arr[_arr.Count - 1];
            _arr.RemoveAt(_arr.Count - 1);
            return last;
        }
    }
}