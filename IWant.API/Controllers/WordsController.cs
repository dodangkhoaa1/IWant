using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IWant.DataAccess;
using IWant.BusinessObject.Enitities;
using IWant.API.Data.DTOs;

namespace IWant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Words
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WordDTO>>> GetWords()
        {
            var words = await _context.Words
                .Include(w => w.WordCategory) // Include related WordCategory if needed
                .ToListAsync();

            var wordDtos = words.Select(word => new WordDTO
            {
                Id = word.Id,
                VietnameseText = word.VietnameseText,
                EnglishText = word.EnglishText,
                CreatedAt = word.CreatedAt,
                UpdatedAt = word.UpdatedAt,
                ImagePath = word.ImagePath,
                Status = word.Status,
                WordCategoryId = word.WordCategoryId,
                WordCategory = word.WordCategory,
                Image = !string.IsNullOrEmpty(word.ImagePath) && System.IO.File.Exists(Path.Combine("wwwroot", word.ImagePath))
                    ? System.IO.File.ReadAllBytes(Path.Combine("wwwroot", word.ImagePath))
                    : null
            }).ToList();

            return Ok(wordDtos);
        }

        // GET: api/Words/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Word>> GetWord(int id)
        {
            var word = await _context.Words.FindAsync(id);

            if (word == null)
            {
                return NotFound();
            }

            return word;
        }

        // PUT: api/Words/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWord(int id, Word word)
        {
            if (id != word.Id)
            {
                return BadRequest();
            }

            _context.Entry(word).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
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

        // POST: api/Words
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Word>> PostWord(Word word)
        {
            _context.Words.Add(word);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWord", new { id = word.Id }, word);
        }

        // DELETE: api/Words/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWord(int id)
        {
            var word = await _context.Words.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            _context.Words.Remove(word);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WordExists(int id)
        {
            return _context.Words.Any(e => e.Id == id);
        }
    }
}
