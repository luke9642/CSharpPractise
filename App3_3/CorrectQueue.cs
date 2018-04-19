using System;
using System.Collections;
using System.Collections.Generic;

namespace App3_3
{
    public class CorrectQueue
    {
        private IList _arr;

        public CorrectQueue(IList list)
        {
            _arr = list;
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