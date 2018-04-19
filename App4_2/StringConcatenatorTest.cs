using System;
using NUnit.Framework;

namespace App4_2
{
    [TestFixture]
    public class StringConcatenatorTest
    {
        [Test]
        public void checkEmptyLeftString()
        {
            Assert.AreEqual(new StringConcatenator().concatenate("", "qwe"), "qwe");
        }
        
        [Test]
        public void checkNullLeftString()
        {
            Assert.Throws<ArgumentNullException>(() => new StringConcatenator().concatenate(null, "qwe"));
        }
        
        [Test]
        public void checkNullRightString()
        {
            Assert.Throws<ArgumentNullException>(() => new StringConcatenator().concatenate("qwe", null));
        }
        
        [Test]
        public void checkNullStrings()
        {
            Assert.Throws<ArgumentNullException>(() => new StringConcatenator().concatenate(null, null));
        }
        
        [Test]
        public void checkNotEmptyStrings()
        {
            Assert.AreEqual(new StringConcatenator().concatenate("qwe", "rty"), "qwerty");
        }
    }
}