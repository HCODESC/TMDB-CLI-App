# TMDB CLI Tool 

Project url https://github.com/HCODESC/TMDB-CLI-App

--- 
### Description

A simple *CLI* tool for searching and displaying data from The Movie 
Database and Display it on the terminal. 

--- 

### Requirements

The application should run from the command line,
and be able to pull and show the popular, top-rated, 
upcoming and now playing movies from the TMDB API. 
The user should be able to specify the type of movies they want to see by passing a command line argument to the CLI tool.

--- 

#### How the CLI should look

```bash
dotnet run --type "playing"
dotnet run  --type "popular"
dotnet run --type "top"
dotnet run  --type "upcoming"
```

#### Project Structure
```
TmdbCli/
├── Commands/                   # Contains command classes for Cocona
│   ├── MovieCommands.cs        # Commands related to movie operations (e.g., search, details)
├── Models/                     # Data models for TMDB API responses
│   ├── Movie.cs                # Movie object model
│   ├── MovieDetail.cs          # Detailed movie info model
├── Services/                   # Business logic and API interaction
│   ├── TmdbService.cs          # Handles API calls to TMDB
│   └── ITmdbService.cs         # Interface for TmdbService (optional, for dependency injection)
├── Configuration/              # Configuration-related files
│   ├── AppSettings.cs          # Strongly-typed settings (e.g., API key)
│   └── appsettings.json        # Configuration file (API key, base URL, etc.)
├── Program.cs                  # Entry point with Cocona setup
├── TmdbCli.csproj              # Project file
└── README.md                   # Project documentation
```



