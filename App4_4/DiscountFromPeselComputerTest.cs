using NUnit.Framework;

namespace App4_4
{
    [TestFixture]
    public class DiscountFromPeselComputerTest
    {
        private IDiscountFromPeselComputer _discountFromPeselComputer;
        
        [SetUp]
        public void Init()
        {
            _discountFromPeselComputer = new DiscountFromPeselComputer();
        }
        
        [TestCase("900905158360")]
        [TestCase("123456789011")]
        [TestCase("1234567890")]
        public void CheckLength(string pesel)
        {
            Assert.Throws<InvalidPeselException>(() => _discountFromPeselComputer.HasDiscount(pesel));
        }
        
        [TestCase("900/./.28360")]
        [TestCase("900@#5282360")]
        [TestCase("900905 83260")]
        [TestCase("12345q789011")]
        [TestCase("1234567890qw")]
        public void CheckIfHasOnlyDigits(string pesel)
        {
            Assert.Throws<InvalidPeselException>(() => _discountFromPeselComputer.HasDiscount(pesel));
        }
        
        [TestCase("90080517456")]
        [TestCase("90060804787")]
        [TestCase("02271409863")]
        [TestCase("90090515837")]
        [TestCase("92071314765")]
        [TestCase("81100216358")]
        [TestCase("80072909147")]
        [TestCase("65071209863")]
        [TestCase("67040500539")]
        public void CheckControlSum(string pesel)
        {
            Assert.Throws<InvalidPeselException>(() => _discountFromPeselComputer.HasDiscount(pesel));
        }
        
        [TestCase("40010177910")]
        [TestCase("01210151403")]
        public void CheckIfHasDiscount(string pesel)
        {
            Assert.IsTrue(_discountFromPeselComputer.HasDiscount(pesel));
        }
        
        [TestCase("90090515836")]
        [TestCase("92071314764")]
        [TestCase("81100216357")]
        [TestCase("80072909146")]
        [TestCase("65071209862")]
        [TestCase("67040500538")]
        public void CheckIfHasNotDiscount(string pesel)
        {
            Assert.IsFalse(_discountFromPeselComputer.HasDiscount(pesel));
        }
    }
}