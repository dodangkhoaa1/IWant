using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IWant.DataAccess;
using IWant.BusinessObject.Enitities;
using IWant.API.Data.DTOs;

namespace IWant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WordCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WordCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WordCategoryDTO>>> GetCategories()
        {
            var categories = await _context.WordCategories
                .ToListAsync();

            var categoryDtos = categories.Select(category => new WordCategoryDTO
            {
                Id = category.Id,
                VietnameseName = category.VietnameseName,
                EnglishName = category.EnglishName,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt,
                ImagePath = category.ImagePath,
                Status = category.Status,
            }).ToList();

            return Ok(categoryDtos);
        }


        // GET: api/WordCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WordCategory>> GetWordCategory(int id)
        {
            var wordCategory = await _context.WordCategories.FindAsync(id);

            if (wordCategory == null)
            {
                return NotFound();
            }

            return wordCategory;
        }

        // PUT: api/WordCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWordCategory(int id, WordCategory wordCategory)
        {
            if (id != wordCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(wordCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordCategoryExists(id))
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

        // POST: api/WordCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WordCategory>> PostWordCategory(WordCategory wordCategory)
        {
            _context.WordCategories.Add(wordCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWordCategory", new { id = wordCategory.Id }, wordCategory);
        }

        // DELETE: api/WordCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWordCategory(int id)
        {
            var wordCategory = await _context.WordCategories.FindAsync(id);
            if (wordCategory == null)
            {
                return NotFound();
            }

            _context.WordCategories.Remove(wordCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WordCategoryExists(int id)
        {
            return _context.WordCategories.Any(e => e.Id == id);
        }
    }
}
