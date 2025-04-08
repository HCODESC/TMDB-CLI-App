using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

namespace tmdbcli.Models;

public class Movie
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("release_date")]
    public DateTime ReleaseDate { get; set; }
    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }
    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }
    [JsonPropertyName("overview")]
    public string Overview { get; set; }
    [JsonPropertyName("original_language")]
    public String OriginalLanguage { get; set; }
}