using Microsoft.AspNetCore.Mvc;
using GameNightAPI.Services;


namespace GameNightAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly GameService _gameService;
        public GamesController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("filter")]
        public IActionResult FilterGames([FromQuery] int? players, [FromQuery] string? mood, [FromQuery] string? difficulty,
                                        [FromQuery] int? age, [FromQuery] int? minDuration, [FromQuery] int? maxDuration)
        {
            var filteredGames = _gameService.Filter(players, mood, difficulty, age, minDuration, maxDuration);
            return Ok(filteredGames);
        }
    }
}
