namespace WeatherApiFacade
{
    public struct Coords
    {
        public string Lat { get; set; }
        public string Lon { get; set; }
    }

    public class WeatherData
    {
        public string City { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string WeatherDescription { get; set; }
    }
}
