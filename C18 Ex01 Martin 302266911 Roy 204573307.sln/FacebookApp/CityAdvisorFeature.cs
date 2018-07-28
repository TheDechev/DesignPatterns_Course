using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using System.Xml;

namespace FacebookApp
{
    internal class CityAdvisorFeature
    {
        XmlDocument m_XmlDoc = new XmlDocument();
        XmlElement m_Root;
        XmlNodeList m_CurrentNode;

        public void fetchXML(string i_SelectedCity)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + i_SelectedCity +
                    ",il&mode=xml&appid=0a08b75b9e93b7524a2642d309468a15";
            m_XmlDoc.Load(url);
            m_Root = m_XmlDoc.DocumentElement;
        }

        public string fetchTemperatureString()
        {
            m_CurrentNode = m_Root.SelectNodes("/current/temperature");
            string currentKelvinTemperature = m_CurrentNode[0].Attributes[0].Value;
            int currentCelsiusTemperature = kelvinToCelsius(float.Parse(currentKelvinTemperature));
            return string.Format("Temperature (celsius): {0} degrees", currentCelsiusTemperature);
        }

        private int kelvinToCelsius(float kelvinTemperature)
        {
            return (int)(kelvinTemperature - 273.15);
        }

        public string fetchHumidityString()
        {
            m_CurrentNode = m_Root.SelectNodes("/current/humidity");
            return string.Format("Humidity: {0}%", m_CurrentNode[0].Attributes[0].Value);
        }

        public string fetchSunriseTime()
        {
            m_CurrentNode = m_Root.SelectNodes("/current/city/sun");
            return string.Format("Sunrise (GMT): {0}", m_CurrentNode[0].Attributes[0].Value);
        }

        public string fetchSunsetTime()
        {
            m_CurrentNode = m_Root.SelectNodes("/current/city/sun");
            return string.Format("Sunset (GMT): {0}", m_CurrentNode[0].Attributes[1].Value);
        }
    }
}
