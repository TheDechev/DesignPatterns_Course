namespace FacebookAppLogic
{
    internal class Humidity : CityData
    {
        public Humidity()
        {
        }

        protected override string DataFormat()
        {
            return "/current/humidity";
        }

        protected override string DataTitle(ref string value)
        {
            return "Humidity: {0}%";
        }

        protected override int ApiInteger()
        {
            return 0;
        }
    }
}