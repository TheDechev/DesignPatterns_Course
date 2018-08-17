using System.Xml;

namespace FacebookApp
{
    internal sealed class CityAdvisorFeature
    {
        private CityAdvisorFeature()
        {
        }

        public static CityAdvisorFeature CityAdvisorInstance
        {
            get
            {
                return CityAdvisorSingleton.sr_instance;
            }
        }

        private class CityAdvisorSingleton
        {
            static CityAdvisorSingleton()
            {
            }

            internal static readonly CityAdvisorFeature sr_instance = new CityAdvisorFeature();
        }

        private XmlDocument m_XmlDoc = new XmlDocument();
        private XmlElement m_Root;
        private XmlNodeList m_CurrentNode;

        public void FetchXML(string i_SelectedCity)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + i_SelectedCity +
                    ",il&mode=xml&appid=0a08b75b9e93b7524a2642d309468a15";
            m_XmlDoc.Load(url);
            m_Root = m_XmlDoc.DocumentElement;
        }

        public string FetchTemperatureString()
        {
            m_CurrentNode = m_Root.SelectNodes("/current/temperature");
            string currentKelvinTemperature = m_CurrentNode[0].Attributes[0].Value;
            int currentCelsiusTemperature = kelvinToCelsius(float.Parse(currentKelvinTemperature));
            return string.Format("Temperature (celsius): {0} degrees", currentCelsiusTemperature);
        }

        private int kelvinToCelsius(float i_KelvinTemperature)
        {
            return (int)(i_KelvinTemperature - 273.15);
        }

        public string FetchHumidityString()
        {
            m_CurrentNode = m_Root.SelectNodes("/current/humidity");
            return string.Format("Humidity: {0}%", m_CurrentNode[0].Attributes[0].Value);
        }

        public string FetchSunriseTime()
        {
            m_CurrentNode = m_Root.SelectNodes("/current/city/sun");
            return string.Format("Sunrise (GMT): {0}", m_CurrentNode[0].Attributes[0].Value);
        }

        public string FetchSunsetTime()
        {
            m_CurrentNode = m_Root.SelectNodes("/current/city/sun");
            return string.Format("Sunset (GMT): {0}", m_CurrentNode[0].Attributes[1].Value);
        }
    }
}
