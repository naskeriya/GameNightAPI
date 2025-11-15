using GameNightAPI.Models;
using System.Globalization;

namespace GameNightAPI.Services;

public class GameService
{
    private readonly List<Game> _games = new()
    {
        new Game(1, "Example Game", "A fun board game for 2-4 players", 2, 4, 10, 30, 60,"Casual","Easy"),
        new Game(2, "Chess", "A fun board game for 2-4 players", 2, 2, 10, 30, 60,"Competitive","Hard"),
        new Game(3, "Catan", "A fun board game for 2-4 players", 2, 4, 10, 30, 60,"Competitive","Medium"),
        new Game(4, "Ticket to Ride", "A fun board game for 2-4 players", 2, 4, 8, 30, 60,"Casual","Easy"),
        new Game(5, "Chess", "A fun board game for 2-4 players", 2, 4, 10, 30, 60,"Casual","Easy"),
        new Game(6, "Chess", "A fun board game for 2-4 players", 2, 4, 10, 30, 60,"Casual","Easy")
    };

    public IEnumerable<Game> Filter(int? players, string? mood, string? difficulty, int? age, int? minDuration, int? maxDuration, IEnumerable<Game>? source = null)
    {
        var query = (source ?? _games).AsEnumerable();

        if (players.HasValue)
            query = query.Where(g => g.MinPlayers <= players && players <= g.MaxPlayers);

        if (!string.IsNullOrWhiteSpace(mood))
            query = query.Where(g => g.Mood.Equals(mood, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(difficulty))
            query = query.Where(g => g.Difficulty.Equals(difficulty, StringComparison.OrdinalIgnoreCase));

        if (age.HasValue)
            query = query.Where(g => g.Age <= age.Value);

        if (minDuration.HasValue)
            query = query.Where(g => g.MinDuration >= minDuration.Value);

        if (maxDuration.HasValue)
            query = query.Where(g => g.MaxDuration <= maxDuration.Value);


        return query;
    }

}
