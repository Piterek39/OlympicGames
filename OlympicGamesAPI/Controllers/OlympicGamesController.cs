using Core.Models;
using Core;
using Infrastructure.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OlympicGamesAPI.Controllers;

    [ApiController, Route("games")]
    public class OlympicGamesController(OlympicGamesDbContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PagedResult<Game>>> GetPagedGames(int pageNumber = 1, int pageSize = 1)
        {
            var games = _context.Games.AsQueryable();

            var totalCount = await games.CountAsync();
            var pagedGames = await games.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Game>
            {
                Items = pagedGames,
                TotalCount = totalCount,
                PageSize = pageSize,
                PageNumber = pageNumber
            };
        }
    [HttpGet("{id}")]
    public IActionResult GetPerson(int id)
    {
        var personEvents = _context.CompetitorEvents
                .Include(ce => ce.Event)
                    .Include(e => e.Medal)
                    .Include(gc=>gc.Competitor)
                .Where(ce => ce.CompetitorId == id)
                .Select(ce => new
                {
                    MedalName = ce.Medal.MedalName,                
                    GameName = ce.Competitor.Games.GamesName,
                    EventName = ce.Event.EventName
                })
                .ToList();

        if (!personEvents.Any())
        {
            return NotFound();
        }

        var person = _context.People
            .Where(p => p.Id == id)
            .Select(p => new
            {
                p.FullName,
                p.Weight,
                p.Height,
                Events = personEvents
            })
            .FirstOrDefault();

        if (person == null)
        {
            return NotFound();
        }

        return Ok(person);
        
    }
    [HttpPost]
    public IActionResult AddGame([FromBody] GameInputModel gameInput)
    {
        
        string gamesName = gameInput.GamesName;
        int gamesYear = gameInput.GamesYear;
        string season = gameInput.Season;

        
        if (gamesYear % 4 != 0)
        {
            return BadRequest("Rok musi byæ podzielny przez 4.");
        }

      
        bool isSummerSeason = season.ToLower() == "summer";
        bool isWinterSeason = season.ToLower() == "winter";
        bool isValidSeason = (gamesYear % 2 == 0 && isWinterSeason) || (gamesYear % 2 != 0 && isSummerSeason);
        if (!isValidSeason)
        {
            return BadRequest($"Nieprawid³owy sezon dla roku {gamesYear}.");
        }

       
        if (_context.Games.Any(g => g.GamesName == gamesName && g.GamesYear == gamesYear && g.Season == season))
        {
            return BadRequest("Olimpiada ju¿ istnieje w bazie.");
        }

      
        var newGame = new Game
        {
            GamesName = gamesName,
            GamesYear = gamesYear,
            Season = season
        };

        _context.Games.Add(newGame);
        _context.SaveChanges();

        return Ok(newGame);
    }
}

//bez bin i obj