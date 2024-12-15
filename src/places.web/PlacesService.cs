using places.lib;
using places.data;

namespace places.web
{
    public class PlacesService : IPlacesService
    {
        private readonly PlacesDbContext _db;

        public PlacesService(PlacesDbContext dbContext)
        {
            _db = dbContext;
        }

        public PlacesWebResponse GetResponse(PlacesWebRequest placesWebRequest)
        {
            var radius = placesWebRequest.Radius;
            var latitude = placesWebRequest.Latitude;
            var longitude = placesWebRequest.Longitude;

            var places =
                _db.Places.AsEnumerable().Select(p => new PlaceWithDistance
                {
                    Place = p,
                    Distance = GeoDistanceCalculator.CalculateDistance(latitude, longitude, p.Latitude, p.Longitude)
                })
                .Where(pwd => pwd.Distance < radius)
                .Where(pwd => placesWebRequest.SearchTerm == null || pwd.Place.LocationName.Contains(placesWebRequest.SearchTerm))
                .Where(pwd => placesWebRequest.Category == null || PlaceTypes.GetCategory(pwd.Place.Type) == placesWebRequest.Category) 
                .ToList();

            return new PlacesWebResponse
            {
                Places = places.Select(pwd => new PlaceItem
                {
                    Id = pwd.Place.Id,
                    Type = pwd.Place.Type,
                    LocationName = pwd.Place.LocationName,
                    Location = $"{pwd.Place.Latitude}/{pwd.Place.Longitude}"

                }).ToList()
            };
        }
    }

    public class PlaceWithDistance
    {
        public double Distance { get; set; }
        public required Place Place { get; set; }
    }

    public interface IPlacesService
    {
        PlacesWebResponse GetResponse(PlacesWebRequest placesWebRequest);
    }
}
