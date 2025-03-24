using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace IWant.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GameController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Allow to get game details
        public async Task<IActionResult> GameDetails()
        {
            var games = await _context.Games.ToListAsync();
            var gameViewModels = _mapper.Map<List<GameViewModel>>(games);
            return View(gameViewModels);
        }

        // Allow to get the list of games
        [Authorize(Roles = "Admin")]
        [Route("Game")]
        [Route("Game/Index")]
        public async Task<IActionResult> Index()
        {
            var games = await _context.Games.ToListAsync();
            var gameViewModels = _mapper.Map<List<GameViewModel>>(games);
            return View(gameViewModels);
        }

        // Allow to get details of a specific game
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            var gameViewModel = _mapper.Map<GameViewModel>(game);
            return View(gameViewModel);
        }

        // Allow to create a new game
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            var gameViewModel = _mapper.Map<GameViewModel>(game);

            return View(gameViewModel);
        }

        // Allow to create a new game (POST)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameViewModel model)
        {
            if (ModelState.IsValid)
            {
                var game = _context.Games.FirstOrDefault(x => x.Id == model.Id);
                if (game == null)
                {
                    return NotFound();
                }
                game.VideoUrl = model.VideoUrl;
                _context.Update(game);
                await _context.SaveChangesAsync();

                TempData["success"] = "Create Video Url successfully!";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Allow to edit a game
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            var gameViewModel = _mapper.Map<GameViewModel>(game);
            return View(gameViewModel);
        }

        // Allow to edit a game (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,VideoUrl")] GameViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var game = _mapper.Map<Game>(model);
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["success"] = "Edit Video Url successfully!";
                RedirectToAction("Index");
            }
            return View(model);
        }

        // Allow to delete a game
        [Route("Game/Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            game.VideoUrl = "";
            _context.Update(game);
            await _context.SaveChangesAsync();

            TempData["success"] = "Delete Video Url successfully!";
            return RedirectToAction("Index");
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
