using System.Xml;

namespace FacebookAppLogic
{
    internal abstract class CityData
    {
        private string value = null;
        private XmlDocument m_XmlDoc = new XmlDocument();

        public string FetchValue(string i_CityName)
        {
            XmlNodeList currentNode = FetchXML(i_CityName).SelectNodes(DataFormat());
            value = currentNode[0].Attributes[ApiInteger()].Value;
            return string.Format(DataTitle(ref value), value);
        }

        private XmlElement FetchXML(string i_SelectedCity)
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