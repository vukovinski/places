using places.web;
using places.data;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication("ApiKeyScheme")
    .AddScheme<AuthenticationSchemeOptions, ApiKeyHandler>("ApiKeyScheme", null);
builder.Services.AddAuthorization();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddTransient<PlacesDbContext>(sp =>
    new PlacesDbContext("Data Source=N:\\Repo\\places\\src\\places.data\\places.db"));
builder.Services.AddTransient<IPlacesService, PlacesService>();
builder.Services.AddTransient<IRequestLogger, RequestLogger>();
builder.Services.AddTransient<IFavoritePlacesService, FavoritePlacesService>();
builder.Services.AddControllers();
builder.Services.AddSignalR();
var app = builder.Build();

app.MapHub<SubscribersHub>("/subscribers");
//app.UseSynchronousAccess();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
