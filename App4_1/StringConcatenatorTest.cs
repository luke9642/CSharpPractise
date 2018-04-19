using NUnit.Framework;

namespace App4_1
{
    [TestFixture]
    public class StringConcatenatorTest
    {
        [Test]
        public void checkEmptyLeftString()
        {
            var stringConcatenator = new StringConcatenator();
            Assert.AreEqual(stringConcatenator.concatenate("", "qwe"), "qwe");
        }
        
        [Test]
        public void checkNullLeftString()
        {
            var stringConcatenator = new StringConcatenator();
            Assert.AreEqual(stringConcatenator.concatenate(null, "qwe"), null);
        }
        
        [Test]
        public void checkNullRightString()
        {
            var stringConcatenator = new StringConcatenator();
            Assert.AreEqual(stringConcatenator.concatenate("qwe", null), null);
        }
        
        [Test]
        public void checkNullStrings()
        {
            var stringConcatenator = new StringConcatenator();
            Assert.AreEqual(stringConcatenator.concatenate(null, null), null);
        }
        
        [Test]
        public void checkNotEmptyStrings()
        {
            var stringConcatenator = new StringConcatenator();
            Assert.AreEqual(stringConcatenator.concatenate("qwe", "rty"), "qwerty");
        }
    }
}