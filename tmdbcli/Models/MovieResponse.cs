using System.Text.Json.Serialization;

namespace tmdbcli.Models;

public class MovieResponse
{
    [JsonPropertyName("results")]
    public List<Movie> Results { get; set; }
}