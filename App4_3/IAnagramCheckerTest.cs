using System;
using NUnit.Framework;

namespace App4_3
{
    [TestFixture]
    public class AnagramCheckerTest
    {
        [TestCase("qwe", "weq")]
        [TestCase("qwe", "qwe")]
        [TestCase("qwe", "qwe")]
        public void IsAnagram(string word1, string word2)
        {
            IAnagramChecker anagramChecker = new AnagramChecker();
            Assert.IsTrue(anagramChecker.IsAnagram(word1, word2));
        }
        
        [TestCase("qwe", "wrq")]
        [TestCase("qwe", "qw")]
        [TestCase("qwe", "qwetrwe")]
        public void IsNotAnagram(string word1, string word2)
        {
            IAnagramChecker anagramChecker = new AnagramChecker();
            Assert.IsFalse(anagramChecker.IsAnagram(word1, word2));
        }
        
        [TestCase(null, null)]
        [TestCase(null, "")]
        [TestCase("qwe", null)]
        public void NullArguments(string word1, string word2)
        {
            IAnagramChecker anagramChecker = new AnagramChecker();
            Assert.Throws<ArgumentNullException>(() => anagramChecker.IsAnagram(word1, word2));
        }
        
        [TestCase("", "")]
        [TestCase("", "qwe")]
        [TestCase("qwe", "")]
        public void EmptyArguments(string word1, string word2)
        {
            IAnagramChecker anagramChecker = new AnagramChecker();
            Assert.Throws<ArgumentException>(() => anagramChecker.IsAnagram(word1, word2));
        }
    }
}