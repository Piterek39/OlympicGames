using Core.Models;
using Core;
using Infrastructure.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OlympicGamesAPI.Controllers;

    [ApiController, Route("game")]
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
}
//bez bin i obj