using System;
using NUnit.Framework;

namespace App4_2
{
    [TestFixture]
    public class StringConcatenatorTest
    {
        [TestCase(null, "qwe")]
        [TestCase("qwe", null)]
        [TestCase(null, null)]
        public void CheckNullString(string word1, string word2)
        {
            Assert.Throws<ArgumentNullException>(() => new StringConcatenator().Concatenate(word1, word2));
        }
        
        [TestCase("qwe", "", "qwe")]
        [TestCase("", "rty", "rty")]
        [TestCase("qwe", "rty", "qwerty")]
        public void CheckStrings(string word1, string word2, string result)
        {
            Assert.AreEqual(new StringConcatenator().Concatenate(word1, word2), result);
        }
    }
}