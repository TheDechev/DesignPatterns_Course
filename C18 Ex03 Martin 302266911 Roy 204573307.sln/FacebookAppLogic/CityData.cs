using System.Xml;

namespace FacebookAppLogic
{
    internal abstract class CityData
    {
        private string m_Value = null;
        private XmlDocument m_XmlDoc = new XmlDocument();

        public string FetchValue(string i_CityName)
        {
            XmlNodeList currentNode = fetchXML(i_CityName).SelectNodes(DataFormat());
            m_Value = currentNode[0].Attributes[ApiInteger()].Value;
            return string.Format(DataTitle(ref m_Value), m_Value);
        }

        private XmlElement fetchXML(string i_SelectedCity)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + i_SelectedCity +
                    ",il&mode=xml&appid=0a08b75b9e93b7524a2642d309468a15";
            m_XmlDoc.Load(url);
            return m_XmlDoc.DocumentElement;
        }

        protected abstract string DataFormat();

        protected abstract string DataTitle(ref string value);

        protected abstract int ApiInteger();
    }
}