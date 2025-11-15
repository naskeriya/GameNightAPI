namespace GameNightAPI.Models;

public record Game(
    int Id,
    string Name,
    string Description,
    int MinPlayers,
    int MaxPlayers,
    int Age,
    int MinDuration,
    int MaxDuration,
    string Mood,
    string Difficulty
);
