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
        XmlDocument m_xmlDoc = new XmlDocument();
        XmlElement m_root;
        XmlNodeList m_currNode;

        public void fetchXML(string i_SelectedCity)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + i_SelectedCity +
                    ",il&mode=xml&appid=0a08b75b9e93b7524a2642d309468a15";
            m_xmlDoc.Load(url);
            m_root = m_xmlDoc.DocumentElement;
        }

        public string fetchTemperatureString()
        {
            m_currNode = m_root.SelectNodes("/current/temperature");
            string currentKelvinTemperature = m_currNode[0].Attributes[0].Value;
            int currentCelsiusTemperature = kelvinToCelsius(float.Parse(currentKelvinTemperature));
            return string.Format("Temperature (celsius): {0} degrees", currentCelsiusTemperature);
        }

        private int kelvinToCelsius(float kelvinTemperature)
        {
            return (int)(kelvinTemperature - 273.15);
        }

        public string fetchHumidityString()
        {
            m_currNode = m_root.SelectNodes("/current/humidity");
            return string.Format("Humidity: {0}%", m_currNode[0].Attributes[0].Value);
        }

        public string fetchSunriseTime()
        {
            m_currNode = m_root.SelectNodes("/current/city/sun");
            return string.Format("Sunrise (GMT): {0}", m_currNode[0].Attributes[0].Value);
        }

        public string fetchSunsetTime()
        {
            m_currNode = m_root.SelectNodes("/current/city/sun");
            return string.Format("Sunset (GMT): {0}", m_currNode[0].Attributes[1].Value);
        }
    }
}
