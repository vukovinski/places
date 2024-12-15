namespace places.web
{
    public class PlacesWebResponse
    {
        public required List<PlaceItem> Places { get; set; }
    }

    public class PlaceItem
    {
        public required string Id { get; set; }
        public required string Location { get; set; }
        public required string LocationName { get; set; }
        public required string Type { get; set; }
    }
}
