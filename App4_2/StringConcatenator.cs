using System;

namespace App4_2
{
    public class StringConcatenator
    {
        public string concatenate(string first, string second)
        {
            if (first == null || second == null)
                throw new ArgumentNullException();
            return first + second;
        }
    }
}