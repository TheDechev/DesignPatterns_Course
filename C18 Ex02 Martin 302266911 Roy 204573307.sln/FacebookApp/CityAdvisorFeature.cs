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

        private int kelvinToCelsius(float i_KelvinTemperature)
        {
            return (int)(i_KelvinTemperature - 273.15);
        }

        private XmlElement FetchXML(string i_SelectedCity)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + i_SelectedCity +
                    ",il&mode=xml&appid=0a08b75b9e93b7524a2642d309468a15";
            m_XmlDoc.Load(url);
            return m_XmlDoc.DocumentElement;
        }

        public string FetchTemperatureString(string i_SelectedCity)
        {
            XmlNodeList currentNode = FetchXML(i_SelectedCity).SelectNodes("/current/temperature");
            string currentKelvinTemperature = currentNode[0].Attributes[0].Value;
            int currentCelsiusTemperature = kelvinToCelsius(float.Parse(currentKelvinTemperature));
            return string.Format("Temperature (celsius): {0} degrees", currentCelsiusTemperature);
        }

        public string FetchHumidityString(string i_SelectedCity)
        {
            XmlNodeList currentNode = FetchXML(i_SelectedCity).SelectNodes("/current/humidity");
            return string.Format("Humidity: {0}%", currentNode[0].Attributes[0].Value);
        }

        public string FetchSunriseTime(string i_SelectedCity)
        {
            XmlNodeList currentNode = FetchXML(i_SelectedCity).SelectNodes("/current/city/sun");
            return string.Format("Sunrise (GMT): {0}", currentNode[0].Attributes[0].Value);
        }

        public string FetchSunsetTime(string i_SelectedCity )
        {
            XmlNodeList currentNode = FetchXML(i_SelectedCity).SelectNodes("/current/city/sun");
            return string.Format("Sunset (GMT): {0}", currentNode[0].Attributes[1].Value);
        }
    }
}
