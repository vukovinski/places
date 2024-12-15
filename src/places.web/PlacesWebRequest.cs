using static places.lib.PlaceTypes;

namespace places.web
{
    public class PlacesWebRequest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; } = 500.0;

        public Category? Category { get; set; } = null;
        public string? SearchTerm { get; set; } = null;
    }
}
