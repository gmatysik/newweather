//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using weather.Model;

namespace test
{
    //[TestClass]
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            Forecast forecast = new Forecast();
            Assert.NotNull(forecast);
        }
    }
}
