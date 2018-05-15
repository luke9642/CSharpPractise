using System;
using System.Linq;

namespace App4_3
{
    public class AnagramChecker : IAnagramChecker
    {
        public bool IsAnagram(string word1, string word2)
        {
            if (word1 == null || word2 == null)
                throw new ArgumentNullException(nameof(word1));
            if (word1 == "" || word2 == "")
                throw new ArgumentException(nameof(word2));
            if (word1.Length != word2.Length)
                return false;

            var processedWord1 = string.Concat(word1.Where(char.IsLetterOrDigit).OrderBy(c => c));
            var processedWord2 = string.Concat(word2.Where(char.IsLetterOrDigit).OrderBy(c => c));
            return string.Equals(processedWord1, processedWord2, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}