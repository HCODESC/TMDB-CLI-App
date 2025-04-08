using System.Globalization;
using Cocona;
using Spectre.Console;
using tmdbcli.Services;

namespace tmdbcli.Commands;

public class TmdbCommands
{
    private readonly ITmdbService _tmdbService; 
    public TmdbCommands(ITmdbService tmdbService)
    {
        _tmdbService = tmdbService;
    }

    [Command("type")]
    public async Task Type([Argument]string type)
    {
        var normalizeType = type.ToLowerInvariant();
        var movies = normalizeType switch {
            "playing" => await _tmdbService.GetCurrentPlayingAsync(),
            "popular" => await _tmdbService.GetPopularMoviesAsync(),
            "top-rated" => await _tmdbService.GetTopRatedMoviesAsync(),
            "upcoming" => await _tmdbService.GetUpcomingMoviesAsync(), 
            _ => throw new ArgumentException($"Invalid type '{type}'. Choose from: playing, popular, top, upcoming.")
        };

        var table = new Table()
            .Collapse()
            .AddColumn(new TableColumn("title").Centered())
            .AddColumn(new TableColumn("overview"))
            .AddColumn(new TableColumn("release date").Centered())
            .AddColumn(new TableColumn("vote average").Centered())
            .AddColumn(new TableColumn("vote count").Centered())
            .AddColumn(new TableColumn("original language").Centered());
        
        table.Border = TableBorder.Ascii2;
            
        
        foreach (var movie in movies)
        {
            table.AddRow(
                movie.Title,
                movie.Overview,
                movie.ReleaseDate.ToShortDateString(),
                movie.VoteAverage.ToString(CultureInfo.InvariantCulture),
                movie.VoteCount.ToString(),
                movie.OriginalLanguage); 
        }
        
        AnsiConsole.Write(table);
    }
}