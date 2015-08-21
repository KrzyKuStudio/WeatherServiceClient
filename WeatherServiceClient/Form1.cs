using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WeatherServiceClient
{
    public partial class Form1 : Form

    {
        WeatherService.WeatherModel weather;
               
        public Form1()
        {
            InitializeComponent();
            CountryDropDownList.DropDownStyle = ComboBoxStyle.DropDownList;
            CityDropDownList.DropDownStyle = ComboBoxStyle.DropDownList;

            weather = new WeatherService.WeatherModel();
                    
            XmlNodeList xmlNodes = weather.GetCountryAndCityData().GetElementsByTagName("Country");
            List<string> countryList = new List<string>();
            foreach (XmlNode node in xmlNodes)
            {
                if (!countryList.Contains(node.InnerText))
                {
                    //Loop through the country names and put them in to a list object
                    countryList.Add(node.InnerText);
                }
            }
            countryList.Sort();

            //Bind the CountryDropDownList control.
            this.CountryDropDownList.DataSource = countryList;
                                   
        }

        private void CountryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
           this.CityDropDownList.DataSource = getList(CountryDropDownList.SelectedItem.ToString());
        }

        /// <summary>
        /// Gets list of City based on Country
        /// </summary>
        /// <param name="Country"></param>
        /// <returns></returns>
        private List<string> getList(string Country)
        {
            XmlNodeList xmlNodes = weather.GetCountryAndCityData().GetElementsByTagName("Country");
                       
            List<string> cityList = new List<string>();

            foreach (XmlNode node in xmlNodes)
            {
                if(node.InnerText == Country)
                {
                    if (!cityList.Contains(node.NextSibling.InnerText))
                    {
                           //Loop through the country names and put them in to a list object
                            cityList.Add(node.NextSibling.InnerText);
                    }
                }
            }
            cityList.Sort();
            return cityList;
        }

        private void CityDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CityDropDownList.SelectedIndexChanged += new System.EventHandler(LoadWeather);
        }

        /// <summary>
        ///    //Get weather information for the selected country and city by using the "GetWeather" service method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadWeather(object sender, System.EventArgs e)
        {
            if (this.CountryDropDownList.SelectedItem != null && this.CityDropDownList.SelectedItem != null)
            {
                String weatherData;
                       
             
                this.Cursor = Cursors.WaitCursor;
                               
                try
                {
                    weatherData = weather.GetWeather(this.CountryDropDownList.SelectedItem.ToString(), this.CityDropDownList.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    weatherData = "The service has responded with an error. " + ex.Message;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                
                }
                this.webBrowser1.DocumentText = weatherData;
               
            }
        }
      
    }
}
