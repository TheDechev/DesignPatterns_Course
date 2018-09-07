namespace FacebookAppLogic
{
    internal class Sunrise : CityData
    {
        public Sunrise()
        {
        }

        protected override string DataFormat()
        {
            return "/current/city/sun";
        }

        protected override string DataTitle(ref string value)
        {
            return "Sunrise (GMT): {0}";
        }

        protected override int ApiInteger()
        {
            return 0;
        }
    }
}