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
        public async Task<ActionResult<Word>> PostWord(WordDTO word)
        {
            if (word.Image != null)
            {
                var category = await _context.WordCategories.FirstOrDefaultAsync(c => c.Id == word.WordCategoryId);
                if (category == null)
                {
                    return BadRequest("Invalid WordCategoryId");
                }

                string categoryFolder = category.EnglishName.ToLower();
                string uniqueFileName = $"{Guid.NewGuid()}.png";
                string savePath = Path.Combine("wwwroot", "images", "word", categoryFolder, uniqueFileName);
                string relativePath = Path.Combine("images", "word", categoryFolder, uniqueFileName).Replace("\\", "/");

                // Save the image to the specified path
                await System.IO.File.WriteAllBytesAsync(savePath, word.Image);

                word.ImagePath = "/" + relativePath;
            }

            Word wordToAdd = new()
            {
                VietnameseText = word.VietnameseText,
                EnglishText = word.EnglishText,
                CreatedAt = word.CreatedAt,
                UpdatedAt = word.UpdatedAt,
                ImagePath = word.ImagePath,
                Status = word.Status,
                WordCategoryId = word.WordCategoryId
            };

            _context.Words.Add(wordToAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWord", new { id = wordToAdd.Id }, wordToAdd);
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
