using places.web;
using places.data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddTransient<PlacesDbContext>(sp =>
    new PlacesDbContext("Data Source=N:\\Repo\\places\\src\\places.data\\places.db"));
builder.Services.AddTransient<IPlacesService, PlacesService>();
builder.Services.AddTransient<IRequestLogger, RequestLogger>();
builder.Services.AddControllers();
var app = builder.Build();

app.UseSynchronousAccess();
app.MapControllers();
app.Run();
