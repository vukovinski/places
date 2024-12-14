public class GooglePlacesRequest
{
    public required GooglePlacesRequestLocationRestriction locationRestriction { get; set; }
}

public class GooglePlacesRequestLocationRestriction
{
    public required GooglePlacesRequestLocationRestrictionCircle circle { get; set; }
}

public class GooglePlacesRequestLocationRestrictionCircle
{
    public required GooglePlacesRequestLocationRestrictionCircleCenter center { get; set; }
    public double radius { get; set; }
}

public class GooglePlacesRequestLocationRestrictionCircleCenter
{
    public required double latitude { get; set; }
    public required double longitude { get; set; }
}