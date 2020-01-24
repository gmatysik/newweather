using System;
using NUnit.Framework;
using weather.Location;

namespace test.Location
{

    [TestFixture]
    public class TestLocationType
    {
        [Test]
        public void TestParseInvalid()
        {
            Enum.TryParse("dupa", out LocationType locationType);
            Assert.AreEqual(LocationType.Empty, locationType);
        }

        [Test]
        public void TestParseCity()
        {
            Enum.TryParse("City", true, out LocationType locationType);
            Assert.AreEqual(LocationType.City, locationType);
        }

        [Test]
        public void TestParseCityCaseInsensitive()
        {
            Enum.TryParse("city", true, out LocationType locationType);
            Assert.AreEqual(LocationType.City, locationType);
        }

        [Test]
        public void TestParseVillage()
        {
            Enum.TryParse("Village", true, out LocationType locationType);
            Assert.AreEqual(LocationType.Village, locationType);
        }

        [Test]
        public void TestParseVillageCaseInsensitive()
        {
            Enum.TryParse("village", true, out LocationType locationType);
            Assert.AreEqual(LocationType.Village, locationType);
        }

    }
}
