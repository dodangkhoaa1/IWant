using IWant.API.Data.DTOs;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _signInManager;

        public UsersController(ApplicationDbContext context, SignInManager<User> signInManager)
        {

            _context = context;
            _signInManager = signInManager;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/dodangkhoaa@gmail.com
        [HttpGet("{userName}")]
        public async Task<ActionResult<User>> GetUserByUserName(string userName)
        {
            var User = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(SigninRequestDto signinRequestDto)
        {
            var result = await _signInManager.PasswordSignInAsync(signinRequestDto.UserName, signinRequestDto.PasswordHash, false, false);

            if (!result.Succeeded) return NotFound();

            User? userInDB = await _context.Users
                .FirstOrDefaultAsync(p => p.UserName == signinRequestDto.UserName);

            return Ok(new SigninResponseDTO()
            {
                FullName = userInDB.FullName,
                Gender = userInDB.Gender,
                Status = userInDB.Status
            });
        }

        private bool UserExists(string userName)
        {
            return _context.Users.Any(e => e.Id == userName);
        }
    }
}
