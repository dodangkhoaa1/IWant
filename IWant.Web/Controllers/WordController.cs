using IWant.BusinessObject.Enitities;
using IWant.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IWant.Web.Controllers
{
    public class WordController : Controller
    {
        private readonly IWordService _wordService;

        public WordController(IWordService wordService)
        {
            _wordService = wordService;
        }

        // Allow to get the list of words
        [Route("Word")]
        [Route("Word/Index")]
        public async Task<IActionResult> Index()
        {
            var words = await _wordService.GetWordsAsync();
            return View(words);
        }

        // Allow to show the create word form
        public async Task<IActionResult> Create()
        {
            var categories = await _wordService.GetCategorysAsync();
            TempData["WordCategories"] = JsonConvert.SerializeObject(categories);
            return View();
        }

        // Allow to create a new word
        [HttpPost]
        public async Task<IActionResult> Create(Word word)
        {
            var createdWord = await _wordService.CreateWordAsync(word);

            if (createdWord?.ImagePath != null)
            {
                word.ImagePath = createdWord.ImagePath;
            }

            TempData["success"] = "Create Word successfully!";
            return RedirectToAction("Index");
        }

        // Allow to delete a word by id
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _wordService.DeleteWordAsync(id);
            if (result)
            {
                TempData["success"] = "Delete Word successfully!";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Delete Word failed.";
            return View("Error");
        }

        // Allow to get the details of a word by id
        public async Task<IActionResult> Details(int id)
        {
            var word = await _wordService.GetWordByIdAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            string fullImagePath = "https://iwantapiservice.azurewebsites.net/" + word.ImagePath;
            word.ImagePath = fullImagePath;

            return View(word);
        }

        // Allow to show the edit word form
        public async Task<IActionResult> Edit(int id)
        {
            var word = await _wordService.GetWordByIdAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            var categories = await _wordService.GetCategorysAsync();
            TempData["WordCategories"] = JsonConvert.SerializeObject(categories);

            string fullImagePath = "https://iwantapiservice.azurewebsites.net/" + word.ImagePath;
            word.ImagePath = fullImagePath;

            return View(word);
        }

        // Allow to update a word
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Word word)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _wordService.GetCategorysAsync();
                TempData["WordCategories"] = JsonConvert.SerializeObject(categories);
                return View(word);
            }

            var updatedWord = await _wordService.UpdateWordAsync(word);
            if (updatedWord == null)
            {
                TempData["error"] = "Update Word failed!";
                return View("Error");
            }

            TempData["success"] = "Update Word successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
