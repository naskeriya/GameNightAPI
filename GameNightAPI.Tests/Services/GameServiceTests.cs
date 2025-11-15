using GameNightAPI.Models;
using GameNightAPI.Services;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace GameNightAPI.Tests.Services
{
    public class GameServiceTests
    {
        private readonly GameService _service = new();

        private List<Game> GetTestGames() => new()
        {
            new Game(1, "A", "...", 1, 2, 8, 10, 20, "Casual", "Easy"),
            new Game(2, "B", "...", 3, 5, 12, 20, 40, "Party", "Medium"),
            new Game(3, "C", "...", 2, 4, 18, 30, 60, "Casual", "Hard"),
        };

        [Fact]
        public void Filter_NoFilters_ReturnsAll()
        {
            var data = GetTestGames();

            var result = _service.Filter(null, null, null, null, null, null, data);

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void Filter_ByPlayers_ShouldReturnCorrect()
        {
            var data = GetTestGames();

            var result = _service.Filter(2, null, null, null, null, null, data);

            Assert.Equal(new[] {1, 3}, result.Select(x => x.Id));
        }

        [Fact]
        public void Filter_ByMood_ShouldReturnCorrect()
        {
            var data = GetTestGames();

            var result = _service.Filter(null, "casual", null, null, null, null, data);

            Assert.Equal(new[] {1, 3}, result.Select(x => x.Id));
        }

        [Fact]
        public void Filter_ByMultipleCriteria_ShouldReturnOne()
        {
            var data = GetTestGames();

            var result = _service.Filter(2, "casual", "Hard", 18, 30, 60, data);

            Assert.Single(result);
            Assert.Equal(3, result.First().Id);
        }

        [Fact]
        public void Filter_NoMatches_ReturnsEmpty()
        {
            var data = GetTestGames();

            var result = _service.Filter(10, null, null, null, null, null, data);

            Assert.Empty(result);
        }
    }
}