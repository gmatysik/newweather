using System;
using NUnit.Framework;
using weather.Location;
using weather.Location.Service;
using weather.Location.Service.LocationApi;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace test.Location.Service
{
    [TestFixture]
    public class TestLocationService
    {

        private ILocationService locationService;

        [SetUp]
        public void SetUp()
        {
            locationService = new LocationService(new OpenCageLocationApiServiceMock());
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestValidResults()
        {
            Task<List<LocationDO>> results = locationService.LocationsForName("");


            var locationsList = results.Result;

            Assert.AreEqual(5, locationsList.Count);
            Assert.AreEqual("90762 Fürth, Germany", locationsList[0].Formatted);
            Assert.AreEqual("64658 Fürth, Germany", locationsList[1].Formatted);
            Assert.AreEqual("2564 Furth, Austria", locationsList[2].Formatted);
            Assert.AreEqual("84095 Furth, Germany", locationsList[3].Formatted);
            Assert.AreEqual("94163 Furth, Germany", locationsList[4].Formatted);

        }

        [Test]
        public void TestCoordinatesDE()
        {
            //ILocationApi locationService = new LocationApiService(new OpenCageLocationApiServiceMock());
            
            LocationDO location = locationService.LocationForCoordinates("49.50", "11.00");
            
            Assert.AreEqual("Fürth", location.City);
            Assert.AreEqual("Germany", location.Country);
        }

        [Test]
        public void TestCoordinatesPL()
        {
            //ILocationApi locationService = new LocationApiService(new OpenCageLocationApiServiceMock());
            
            LocationDO location = locationService.LocationForCoordinates("51.10", "17.00");
            
            Assert.AreEqual("Wroclaw", location.City);
            Assert.AreEqual("Poland", location.Country);
            Assert.AreEqual("53-441, Wroclaw, Poland", location.ToString());

        }

    }
}
