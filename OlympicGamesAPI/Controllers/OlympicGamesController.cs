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
    }
