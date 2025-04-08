using tmdbcli.Models;

namespace tmdbcli.Services;

public interface ITmdbService
{
  Task<List<Movie>> GetCurrentPlayingAsync(); 
  Task<List<Movie>> GetPopularMoviesAsync(); 
  Task<List<Movie>> GetTopRatedMoviesAsync();
  Task<List<Movie>> GetUpcomingMoviesAsync(); 
}