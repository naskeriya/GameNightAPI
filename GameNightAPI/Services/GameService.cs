using GameNightAPI.Models;
using System.Globalization;

namespace GameNightAPI.Services;

public class GameService
{
    private readonly List<Game> _games = new()
    {
        new Game(1, "Catan", "A strategic economic game about settling an island", 3, 4, 10, 60, 120, "Strategy", "Medium"),
        new Game(2, "Carcassonne", "A tile-placing game about building medieval landscapes", 2, 5, 7, 30, 45, "Tile-laying", "Easy"),
        new Game(3, "Ticket to Ride", "Build train routes across the map", 2, 5, 8, 45, 60, "Family", "Easy"),
        new Game(4, "Pandemic", "Cooperative game about stopping global diseases", 2, 4, 10, 45, 60, "Co-op", "Medium"),
        new Game(5, "Dixit", "A storytelling game with beautiful illustrations", 3, 6, 8, 30, 30, "Party", "Easy"),
        new Game(6, "7 Wonders", "Build your ancient civilization through cards", 3, 7, 10, 30, 40, "Strategy", "Medium"),
        new Game(7, "Splendor", "Collect gems and develop trade routes", 2, 4, 10, 30, 45, "Strategy", "Easy"),
        new Game(8, "Codenames", "A team-based word and association game", 2, 8, 14, 15, 30, "Party", "Easy"),
        new Game(9, "Azul", "A beautiful abstract game about creating mosaics", 2, 4, 8, 30, 45, "Abstract", "Medium"),
        new Game(10, "Uno", "A classic card game where you try to discard all cards", 2, 10, 7, 15, 20, "Casual", "Easy"),
        new Game(11, "Monopoly", "Buy property and bankrupt opponents", 2, 6, 8, 60, 180, "Family", "Medium"),
        new Game(12, "Chess", "Classic strategic war game for two players", 2, 2, 6, 10, 60, "Abstract", "Hard"),
        new Game(13, "Checkers", "Simple tactical board game for two", 2, 2, 6, 10, 20, "Abstract", "Easy"),
        new Game(14, "Jenga", "Remove blocks without collapsing the tower", 1, 8, 6, 10, 20, "Party", "Easy"),
        new Game(15, "Mysterium", "Solve a murder mystery with surreal clues", 2, 7, 10, 45, 90, "Co-op", "Medium"),
        new Game(16, "Scythe", "Engine-building strategy in an alternate 1920s Europe", 1, 5, 14, 90, 120, "Strategy", "Hard"),
        new Game(17, "Gloomhaven", "Tactical combat in a rich fantasy campaign", 1, 4, 14, 90, 150, "Adventure", "Hard"),
        new Game(18, "Cluedo", "Classic detective game about solving a murder", 2, 6, 8, 45, 60, "Mystery", "Easy"),
        new Game(19, "Risk", "Global domination through strategy and battles", 2, 6, 10, 120, 240, "Strategy", "Medium"),
        new Game(20, "The Resistance", "Bluffing and deduction in a secret-identity setting", 5, 10, 13, 15, 30, "Party", "Easy"),
        new Game(21, "Secret Hitler", "Hidden-role game about deception and strategy", 5, 10, 13, 45, 90, "Party", "Medium"),
        new Game(22, "Terraforming Mars", "Develop corporations to terraform the Red Planet", 1, 5, 12, 120, 180, "Strategy", "Hard"),
        new Game(23, "Love Letter", "Quick deduction card game with simple rules", 2, 4, 10, 15, 20, "Casual", "Easy"),
        new Game(24, "King of Tokyo", "Battle monsters to control Tokyo", 2, 6, 8, 20, 30, "Family", "Easy"),
        new Game(25, "Patchwork", "Two-player puzzle game about sewing quilts", 2, 2, 8, 20, 30, "Abstract", "Easy"),
        new Game(26, "Wingspan", "Engine-building game about attracting birds", 1, 5, 10, 40, 70, "Strategy", "Medium"),
        new Game(27, "Talisman", "Fantasy adventure through magical realms", 2, 6, 12, 90, 120, "Adventure", "Medium"),
        new Game(28, "The Mind", "Silent cooperative card sequencing challenge", 2, 4, 8, 10, 20, "Co-op", "Easy"),
        new Game(29, "Bang!", "Wild West card game of hidden roles and shooting", 4, 7, 10, 20, 40, "Party", "Medium"),
        new Game(30, "Dominion", "The original deck-building strategy game", 2, 4, 13, 30, 40, "Strategy", "Medium"),
        new Game(31, "Arkham Horror", "Cooperative Lovecraftian investigation and survival", 1, 6, 14, 120, 180, "Co-op", "Hard"),
        new Game(32, "Everdell", "Beautiful forest-kingdom worker placement game", 1, 4, 10, 40, 80, "Strategy", "Medium"),
        new Game(33, "Hive", "Abstract insect-themed strategy for two", 2, 2, 9, 10, 20, "Abstract", "Medium"),
        new Game(34, "Just One", "Cooperative word-guessing party game", 3, 7, 8, 20, 20, "Party", "Easy"),
        new Game(35, "Sushi Go!", "Fast-paced drafting game about collecting sushi sets", 2, 5, 8, 15, 20, "Family", "Easy"),
        new Game(36, "Calico", "A cozy puzzle game about quilting patterns", 1, 4, 10, 30, 45, "Abstract", "Medium"),
        new Game(37, "Root", "Asymmetrical woodland warfare", 2, 4, 10, 60, 90, "Strategy", "Hard"),
        new Game(38, "Spirit Island", "Cooperative defense against colonizers", 1, 4, 13, 90, 120, "Co-op", "Hard"),
        new Game(39, "Decrypto", "Team communication and code-cracking game", 3, 8, 12, 30, 45, "Party", "Medium"),
        new Game(40, "Cartographers", "Map-drawing flip-and-write fantasy game", 1, 8, 10, 30, 45, "Strategy", "Easy"),
        new Game(41, "Sheriff of Nottingham", "Bluff, bribe and smuggle goods past the sheriff", 3, 5, 13, 45, 60, "Party", "Medium"),
        new Game(42, "Tiny Towns", "Build a small town with spatial puzzles", 1, 6, 10, 45, 60, "Strategy", "Medium"),
        new Game(43, "The Crew", "Cooperative trick-taking missions in space", 2, 5, 10, 20, 40, "Co-op", "Medium"),
        new Game(44, "Cascadia", "Nature-themed tile-laying puzzle game", 1, 4, 10, 30, 45, "Abstract", "Easy"),
        new Game(45, "Kingdomino", "Build a kingdom by drafting domino tiles", 2, 4, 8, 15, 20, "Family", "Easy"),
        new Game(46, "Forbidden Island", "Cooperative treasure-hunting adventure", 2, 4, 10, 30, 45, "Co-op", "Easy"),
        new Game(47, "Magic: The Gathering", "Fantasy card duels with endless deckbuilding", 2, 2, 13, 20, 60, "Cards", "Hard"),
        new Game(48, "Agricola", "Deep farming and worker-placement strategy", 1, 5, 12, 90, 120, "Strategy", "Hard"),
        new Game(49, "Saboteur", "Hidden-role mining adventure with betrayals", 3, 10, 8, 30, 45, "Party", "Easy"),
        new Game(50, "Exploding Kittens", "Hilarious chaotic card game about avoiding explosions", 2, 5, 7, 15, 20, "Party", "Easy"),
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
