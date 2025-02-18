using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;

namespace IWant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalWordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonalWordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PersonalWords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalWord>>> GetPersonalWords()
        {
            return await _context.PersonalWords.Include(pw => pw.User).Include(pw => pw.WordCategory).ToListAsync();
        }

        // GET: api/PersonalWords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalWord>> GetPersonalWord(int id)
        {
            var personalWord = await _context.PersonalWords
                .Include(pw => pw.User)
                .Include(pw => pw.WordCategory)
                .FirstOrDefaultAsync(pw => pw.Id == id);

            if (personalWord == null)
            {
                return NotFound();
            }

            return personalWord;
        }

        // PUT: api/PersonalWords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalWord(int id, PersonalWord personalWord)
        {
            if (id != personalWord.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalWord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalWordExists(id))
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

        // POST: api/PersonalWords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonalWord>> PostPersonalWord(PersonalWord personalWord)
        {
            int PERSONAL_WORD_CATEGORY_ID = 1;
            personalWord.WordCategoryId = PERSONAL_WORD_CATEGORY_ID;
            _context.PersonalWords.Add(personalWord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalWord", new { id = personalWord.Id }, personalWord);
        }

        // DELETE: api/PersonalWords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalWord(int id)
        {
            var personalWord = await _context.PersonalWords.FindAsync(id);
            if (personalWord == null)
            {
                return NotFound();
            }

            _context.PersonalWords.Remove(personalWord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalWordExists(int id)
        {
            return _context.PersonalWords.Any(e => e.Id == id);
        }
    }
}
