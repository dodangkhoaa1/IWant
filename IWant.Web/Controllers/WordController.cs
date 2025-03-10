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

        public async Task<IActionResult> Index()
        {
            var words = await _wordService.GetWordsAsync();
            return View(words);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _wordService.GetCategorysAsync();
            TempData["WordCategories"] = JsonConvert.SerializeObject(categories);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Word word)
        {
            var createdWord = await _wordService.CreateWordAsync(word);

            if (createdWord?.ImagePath != null)
            {
                word.ImagePath = createdWord.ImagePath;
            }

            return RedirectToAction("Index"); 
        }


    }
}
