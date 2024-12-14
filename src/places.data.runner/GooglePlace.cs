public class GooglePlace
{
    public string name { get; set; }
    public string id { get; set; }
    public GooglePlaceDisplayName displayName { get; set; }
    public List<string> types { get; set; }
    public string primaryType { get; set; }
    public GooglePlaceLocation location { get; set; }
    public float rating { get; set; }
    public string googleMapsUri { get; set; }
    public string websiteUri { get; set; }
}

public class GooglePlaceLocation
{
    public double latitude { get; set; }
    public double longitude { get; set; }
}

public class GooglePlaceDisplayName
{
    public string text { get; set; }
    public string languageCode { get; set; }
}