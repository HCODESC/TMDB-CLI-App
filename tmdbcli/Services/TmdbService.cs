using System.Text.Json;
using Microsoft.Extensions.Logging;
using tmdbcli.Models;

namespace tmdbcli.Services;

public class TmdbService : ITmdbService
{
    
    private readonly HttpClient _httpClient;
    private readonly ILogger<TmdbService> _logger;
    public TmdbService(IHttpClientFactory httpClientFactory, ILogger<TmdbService> logger)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient("tmdb");
    }
    
    public async Task<List<Movie>> GetCurrentPlayingAsync()
    {
        
        var response = await _httpClient.GetAsync("movie/now_playing");

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Error from TMDB: {Status}", response.StatusCode);
            return new List<Movie>();
        }

     
        var json = await response.Content.ReadAsStringAsync();

        try
        {
            var tmdbResponse = JsonSerializer.Deserialize<MovieResponse>(json);
            return tmdbResponse?.Results ?? new List<Movie>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Deserialization failed.");
            return new List<Movie>();
        }
    }

    public async Task<List<Movie>> GetPopularMoviesAsync()
    {
       var response = await _httpClient.GetAsync("movie/popular");
       if (!response.IsSuccessStatusCode)
       {
           _logger.LogError("Error from TMDB: {Status}", response.StatusCode);
           return new List<Movie>();
       }

       var json = await response.Content.ReadAsStringAsync();

       try
       {
            var tmdbResponse = JsonSerializer.Deserialize<MovieResponse>(json);
            return tmdbResponse?.Results ?? new List<Movie>();
       }
       catch (Exception e)
       {
           _logger.LogError(e, "Deserialization failed.");
           return new List<Movie>(); 
       }
    }

    public async Task<List<Movie>> GetTopRatedMoviesAsync()
    {
        var response = await _httpClient.GetAsync("movie/top_rated");

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Error from TMDB: {status}", response.StatusCode);
            return new List<Movie>();
        }
        
        var json = await response.Content.ReadAsStringAsync();

        try
        {
            var tmdbResponse = JsonSerializer.Deserialize<MovieResponse>(json); 
            return tmdbResponse?.Results ?? new List<Movie>();
        }
        catch (Exception e)
        { 
            _logger.LogError(e, "Deserialization failed.");
            return new List<Movie>();
        }
    }

    public async Task<List<Movie>> GetUpcomingMoviesAsync()
    {
        var response = await _httpClient.GetAsync("movie/upcoming");

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Error from TMDB: {status}", response.StatusCode);
            return new List<Movie>();
        }

        var json = await response.Content.ReadAsStringAsync();

        try
        {
            var tmdbResponse = JsonSerializer.Deserialize<MovieResponse>(json);
            return tmdbResponse?.Results ?? new List<Movie>();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Deserialization failed.");
            return new List<Movie>();
        }
    }
}