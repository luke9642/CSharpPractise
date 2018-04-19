using System;
using System.Linq;

namespace App4_3
{
    public class AnagramChecker : IAnagramChecker
    {
        public bool IsAnagram(string word1, string word2)
        {
            if (word1 == null)
                throw new ArgumentNullException(nameof(word1));
            if (word2 == null)
                throw new ArgumentNullException(nameof(word2));
            if (word1.Length != word2.Length)
                return false;

            return string.Concat(word1.OrderBy(c => c)) == string.Concat(word2.OrderBy(c => c));
        }
    }
}