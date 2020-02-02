using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using weather.Data.Json;
using weather.Location;
using weather.Location.Service.LocationApi;

namespace test.Location
{

    [TestFixture]
    public class TestLocationApiService
    {
        [Test]
        public void TestCoordinatesDE()
        {
            ILocationApi locationService = new LocationApiService(new OpenCageLocationApiServiceMock());
            
            LocationDO location = locationService.LocationForCoordinates("49.50", "11.00");
            
            Assert.AreEqual("Fürth", location.City);
            Assert.AreEqual("Germany", location.Country);
        }

        [Test]
        public void TestCoordinatesPL()
        {
            ILocationApi locationService = new LocationApiService(new OpenCageLocationApiServiceMock());
            
            LocationDO location = locationService.LocationForCoordinates("51.10", "17.00");
            
            Assert.AreEqual("Wroclaw", location.City);
            Assert.AreEqual("Poland", location.Country);
            Assert.AreEqual("53-441, Wroclaw, Poland", location.ToString());

        }

        [Test]
        public void TestLocationForName() 
        {
            ILocationApi locationService = new LocationApiService(new OpenCageLocationApiServiceMock());
            var taskList = locationService.LocationsForName("test");

            var locationsList = taskList.Result;

            Assert.AreEqual(5, locationsList.Count);
            Assert.AreEqual("Germany", locationsList[0].Country);
            Assert.AreEqual("Fürth", locationsList[0].City);
            Assert.AreEqual(LocationType.City, locationsList[0].Type);

        }

    }
}
