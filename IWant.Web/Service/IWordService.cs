using IWant.BusinessObject.Enitities;

namespace IWant.Web.Service
{
    public interface IWordService
    {
        Task<List<Word>> GetWordsAsync();
        Task<Word> GetWordByIdAsync(int id);
        Task<Word> CreateWordAsync(Word word);
        Task<Word> UpdateWordAsync(Word word);
        Task<bool> DeleteWordAsync(int id);

        Task<List<WordCategory>> GetCategorysAsync();
        Task<WordCategory> GetWordCategoryByIdAsync(int id);

    }
}
