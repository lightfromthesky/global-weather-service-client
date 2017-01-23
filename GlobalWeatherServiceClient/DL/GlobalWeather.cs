using System.Linq;
using GlobalWeatherClient.Models;
using System.IO;
using System.Xml.Serialization;
using System;

namespace GlobalWeatherServiceClient.DL
{
    public static class GlobalWeather
    {
        public static string GetCitiesByCountry(string countryName)
        {
            string serviceResult = string.Empty;

            try
            {
                using (GlobalWeatherService.GlobalWeatherSoapClient service = new GlobalWeatherService.GlobalWeatherSoapClient("GlobalWeatherSoap"))
                {
                    serviceResult = service.GetCitiesByCountry(countryName);
                }
            }
            catch (Exception ex)
            {
                //log exception ex
                throw;
            }

            return serviceResult;
        }

        public static string GetCitiesByCountryJSON(string countryName)
        {
            var serviceResult = GetCitiesByCountry(countryName);

            if(string.IsNullOrEmpty(serviceResult))
            {
                return serviceResult;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(NewDataSet));
            NewDataSet citiesByCountry;

            using (TextReader reader = new StringReader(serviceResult))
            {
                citiesByCountry = (NewDataSet)serializer.Deserialize(reader);
            }

            var citiesByCountryJSON = (from table in citiesByCountry.Tables
                                       select new { City = table.City, Country = table.Country });

            return Newtonsoft.Json.JsonConvert.SerializeObject(citiesByCountryJSON);
        }
    }
}