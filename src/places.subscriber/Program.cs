using Microsoft.AspNetCore.SignalR.Client;

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5073/subscribers")
    .Build();

connection.On<double, double>("NewSearch", (lat, lon) =>
{
    Console.WriteLine($"New search around coordinates: {lat}/{lon}");
});

await connection.StartAsync();
Console.ReadLine();
await connection.StopAsync();