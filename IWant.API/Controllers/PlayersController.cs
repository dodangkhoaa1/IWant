using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IWant.API.Data;
using IWant.API.Data.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PlayersController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.id)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPut("SaveScore")]
        public async Task<IActionResult> SaveScore(SaveScoreDto saveScoreDto)
        {
            Player? playerInDb = await _context.Players.FirstOrDefaultAsync(p => p.username == saveScoreDto.username);
            if (playerInDb == null) return NotFound();
            playerInDb.score = saveScoreDto.score;
            _context.Update(playerInDb);
            await _context.SaveChangesAsync();
            return Ok(playerInDb);
        }

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.id }, player);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Player>> Login(LoginRequestDto loginRequestDto)
        {
            Player? playerInDB = null;
            playerInDB = await _context.Players
                .FirstOrDefaultAsync(p => p.username == loginRequestDto.username
                                            && p.password == loginRequestDto.password);
            if (playerInDB == null) return NotFound();
            return Ok(playerInDB);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.id == id);
        }
    }
}
