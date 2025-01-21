// get location from args
// call google places api (nearby search)
// store places to database

using System.Text;
using Spectre.Console;
using System.Text.Json;
using System.Net.Http.Json;

using places.data;

if (args.Length >= 2)
{
    var radius = 1000.0;
    var latitude = double.Parse(args[0]);
    var longitude = double.Parse(args[1]);
    var includedTypes = args.Length > 2 ? args[2] : null;
    var googlePlacesApiKey = "REDACTED_GOOGLE_PLACES_API_KEY";
    var googlePlacesApi = new Uri ("https://places.googleapis.com/v1/places:searchNearby");
    var database = new PlacesDbContext("Data Source=N:\\Repo\\places\\src\\places.data\\places.db");


    var requestData = new GooglePlacesRequest
    {
        locationRestriction = new GooglePlacesRequestLocationRestriction
        {
            circle = new GooglePlacesRequestLocationRestrictionCircle
            {
                center = new GooglePlacesRequestLocationRestrictionCircleCenter
                {
                    latitude = latitude,
                    longitude = longitude
                },
                radius = radius
            }
        },
        includedTypes = includedTypes != null ? [includedTypes] : []
    };
    var requestDataRaw = JsonSerializer.Serialize(requestData);
    var requestHttpClient = new HttpClient();
    var requestMessage = new HttpRequestMessage()
    {
        Method = HttpMethod.Post,
        RequestUri = googlePlacesApi,
        Content = new StringContent(requestDataRaw, Encoding.UTF8, "application/json")
    };
    requestMessage.Headers.Add("X-Goog-Api-Key", googlePlacesApiKey);
    requestMessage.Headers.Add("X-Goog-FieldMask", "*");

    var requestTask = await requestHttpClient.SendAsync(requestMessage);
    var response = await requestTask.Content.ReadFromJsonAsync<GooglePlacesResponse>();
    var places = response!.places.Select(p => new Place()
    {
        Id = p.id,
        LocationName = p.displayName.text,
        Latitude = p.location.latitude,
        Longitude = p.location.longitude,
        Type = p.primaryType,
        LocationData = JsonSerializer.Serialize(p)

    }).ToList();
    
    foreach (var place in places)
    {
        if (!database.Places.Any(p => p.Id == place.Id))
        {
            await database.Places.AddAsync(place);
        }
    }
    await database.SaveChangesAsync();

    AnsiConsole.WriteLine($"Saved {places.Count} places around {latitude} {longitude} in a {radius} m.");
}

