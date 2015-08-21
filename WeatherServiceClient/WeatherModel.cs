using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace WeatherService
{
    class WeatherModel
    {
        TemporaryWeatherFile temporaryWeatherFile;
        string countryName;
        string cityName;

        /// <summary>
        /// Gets from web service Country and City list
        /// </summary>
        /// <returns>temporaryWeatherFile.XmlDoc</returns>
        public XmlDocument GetCountryAndCityData()
        {
            WeatherServiceClient.net.webservicex.www.GlobalWeather client = new WeatherServiceClient.net.webservicex.www.GlobalWeather();
            DateTime nowTime = DateTime.Now;
            
            //Load file from disk if not empty or last update not so long ago xxx (xxx ticks ago)
            if (temporaryWeatherFile.Length() > 0 &&
                     (nowTime.Ticks - temporaryWeatherFile.TimeTemporaryFile.Ticks) < 600000000000 // 1 minute
                )
            {
                if(!temporaryWeatherFile.InMemory)
                {
                    temporaryWeatherFile.LoadFromDisk();
                }
                
            }
            else
            {
                // Gets from service all Country and City
                temporaryWeatherFile.LoadXml(client.GetCitiesByCountry(""));
            }

            return temporaryWeatherFile.XmlDoc;
        }

        /// <summary>
        /// Constructor creating WeatherModel
        /// </summary>
        public WeatherModel()
        {
            string temporaryFilePath = @"C:/Temp/weatherXML.xml";
            string temporaryDirectoryPath = @"C:/Temp";
            temporaryWeatherFile = new TemporaryWeatherFile(temporaryFilePath, temporaryDirectoryPath);

            GetCountryAndCityData();
        }

        /// <summary>
     /// Gets weather from service for Country and City
     /// </summary>
     /// <param name="Country"></param>
     /// <param name="City"></param>
     /// <returns></returns>
        public string GetWeather(string Country, string City)
        {
            WeatherServiceClient.net.webservicex.www.GlobalWeather client = new WeatherServiceClient.net.webservicex.www.GlobalWeather();
            StringBuilder sb = new StringBuilder();
            string xmlStr = client.GetWeather(City, Country);

            XmlDocument xmlDoc = new XmlDocument();
            //Load the xml string data into xml document
            xmlDoc.LoadXml(xmlStr);
            bool success = false;
            XmlNode xmlNode = xmlDoc.DocumentElement;
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.Name == "Status")
                {
                    success = node.InnerText == "Success";
                }
                else
                {
                    //Loop through the nodes and put the information in the StringBuilder object.
                    sb.Append("<b>" + node.Name + ":</b> " + node.InnerText + "<br />");
                }
            }
            if (success)
            {
                return sb.ToString();
            }
            else
            {
                return "Data Not Found";
            }

        }
    }
}
