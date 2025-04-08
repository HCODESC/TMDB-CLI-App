
using System.Net.Http.Headers;
using Cocona;
using Microsoft.Extensions.DependencyInjection;
using tmdbcli.Commands;
using tmdbcli.Services;

var builder = CoconaApp.CreateBuilder();
var configuration = builder.Configuration; 
string? apikey = configuration["apisettings:apikey"];

builder.Services.AddHttpClient("tmdb", client => {
    client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

});
builder.Services.AddSingleton<ITmdbService, TmdbService>(); 

var app = builder.Build();

app.AddCommands<TmdbCommands>(); 

app.Run();

