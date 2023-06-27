using NUnit.Framework;
using DemoLibrary;

namespace DemoLibrary.UnitTests.Services
{
    [TestFixture]
    public class DemoLibrary_IsOddhould
    {
        private DemoLibrary? _demoService;

        [SetUp]
        public void SetUp()
        {
            _demoService = new DemoLibrary();
        }

        [Test]
        public void IsOdd_InputIs1_ReturnTrue()
        {
            var result = _demoService?.IsOddNumber(1);

            Assert.IsTrue(result, "Value should be odd number");
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(13)]
        public void IsOdd_InputOddNumbers_ReturnTrue(int candidate)
        {
            var result = _demoService?.IsOddNumber(candidate);

            Assert.IsTrue(result, "Value should be odd number");
        }

        [TestCase(2)]
        [TestCase(6)]
        [TestCase(20)]
        public void IsOdd_InputEvenNumbers_ReturnFalse(int candidate)
        {
            var result = _demoService?.IsOddNumber(candidate);

            Assert.IsFalse(result, "Value should be even number");
        }
    }
}