using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlobalWeatherServiceClient.DL;

namespace GlobalWeatherServiceClient.Tests.DL.Tests
{
    [TestClass]
    public class GlobalWeatherTests
    {
        public string noDataOrCitiesResult;

        [TestInitialize]
        public void Setup_GlobalWeatherTestsData()
        {
            //Web service returns the following 
            //when NO cities are found for a country
            noDataOrCitiesResult = "<NewDataSet />";
        }

        [TestMethod]
        public void GetCitiesByCountry_ValidCountry_GetCities()
        {
            var actualResult = GlobalWeather.GetCitiesByCountry("India");
            Assert.AreNotEqual(noDataOrCitiesResult, actualResult);
        }

        [TestMethod]
        public void GetCitiesByCountry_InvalidCountry_DoNotGetCities()
        {
            var actualResult = GlobalWeather.GetCitiesByCountry("xxxxx");
            Assert.AreEqual(noDataOrCitiesResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException))]
        public void GetCitiesByCountry_PassNullInput_DoNotGetCities()
        {
            var actualResult = GlobalWeather.GetCitiesByCountry(null);
        }
    }
}
