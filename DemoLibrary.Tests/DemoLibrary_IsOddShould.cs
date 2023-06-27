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
    }
}