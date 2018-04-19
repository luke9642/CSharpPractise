using NUnit.Framework;

namespace App4_3
{
    [TestFixture]
    public class IAnagramCheckerTest
    {
        [Test]
        public void a()
        {
            Assert.IsTrue(new AnagramChecker().IsAnagram("qwe", "ewq"));
        }
        
        [Test]
        public void a()
        {
            Assert.IsTrue(new AnagramChecker().IsAnagram("qwe", "ewq"));
        }
    }
}