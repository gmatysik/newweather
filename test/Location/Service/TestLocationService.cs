using System;
using NUnit.Framework;
using weather.Location;
using weather.Location.Service;
using weather.Location.Service.LocationApi;

namespace test.Location.Service
{
    [TestFixture]
    public class TestLocationService
    {

        private ILocationService locationService;

        [SetUp]
        public void SetUp()
        {
            locationService = new LocationService(new LocationApiService(new OpenCageLocationApiServiceMock()));
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestParseInvalid()
        {
            locationService.LocationsForName("");
        }

    }
}
