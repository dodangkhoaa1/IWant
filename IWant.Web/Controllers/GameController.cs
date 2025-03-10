using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using AutoMapper;

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

        public async Task<IActionResult> GameDetails()
        {
            var games = await _context.Games.ToListAsync();
            var gameViewModels = _mapper.Map<List<GameViewModel>>(games);
            return View(gameViewModels);
        }

        // GET: Game
        [Route("Game")]
        [Route("Game/Index")]
        public async Task<IActionResult> Index()
        {
            var games = await _context.Games.ToListAsync();
            var gameViewModels = _mapper.Map<List<GameViewModel>>(games);
            return View(gameViewModels);
        }

        // GET: Game/Details/5
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

        // GET: Game/Create
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

        // POST: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameViewModel model)
        {
            if (ModelState.IsValid)
            {
                var game = _context.Games.FirstOrDefault(x => x.Id == model.Id);
                if(game == null)
                {
                    return NotFound();
                }
                game.VideoUrl = model.VideoUrl;
                _context.Update(game);
                await _context.SaveChangesAsync();

                TempData["success"] = "Create Video Url successful!";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Game/Edit/5
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

        // POST: Game/Edit/5
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
                TempData["success"] = "Edit Video Url successful!";
                RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Game/Delete/5
        [Route("Game/Delete/{id}")]
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

            TempData["success"] = "Delete Video Url successful!";
            return RedirectToAction("Index");
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
