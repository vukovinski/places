namespace places.data
{
    public class Place
    {
        public required string Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public required string Type { get; set; }
        public required string LocationName { get; set; }
        public required string LocationData { get; set; }
    }
}
