using NUnit.Framework;

namespace App4_1
{
    [TestFixture]
    public class StringConcatenatorTest
    {
        [TestCase(null, "qwe")]
        [TestCase("qwe", null)]
        [TestCase(null, null)]
        public void CheckNullString(string word1, string word2)
        {
            Assert.IsNull(word1.Concatenate(word2));
        }
        
        [TestCase("qwe", "", "qwe")]
        [TestCase("", "rty", "rty")]
        [TestCase("qwe", "rty", "qwerty")]
        public void CheckStrings(string word1, string word2, string result)
        {
            Assert.AreEqual(word1.Concatenate(word2), result);
        }
    }
}