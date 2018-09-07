namespace FacebookAppLogic
{
    internal class Sunset : CityData
    {
        public Sunset()
        {
        }

        protected override string DataFormat()
        {
            return "/current/city/sun";
        }

        protected override string DataTitle(ref string value)
        {
            return "Sunset (GMT): {0}";
        }

        protected override int ApiInteger()
        {
            return 1;
        }
    }
}