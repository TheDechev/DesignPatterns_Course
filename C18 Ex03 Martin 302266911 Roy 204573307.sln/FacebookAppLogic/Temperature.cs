namespace FacebookAppLogic
{
    internal class Temperature : CityData
    {
        public Temperature()
        {
        }

        protected override string DataFormat()
        {
            return "/current/temperature";
        }

        protected override string DataTitle(ref string value)
        {
            string currentKelvinTemperature = value;
            int currentCelsiusTemperature = kelvinToCelsius(float.Parse(currentKelvinTemperature));
            value = currentCelsiusTemperature.ToString();
            return "Temperature (celsius): {0} degrees";
        }

        protected override int ApiInteger()
        {
            return 0;
        }

        private int kelvinToCelsius(float i_KelvinTemperature)
        {
            return (int)(i_KelvinTemperature - 273.15);
        }
    }
}