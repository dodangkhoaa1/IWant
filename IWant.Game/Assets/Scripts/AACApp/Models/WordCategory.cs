using System;
#nullable enable
namespace Assets.Scripts.AACApp.Models
{
    [Serializable]
    public class WordCategory
    {
        public int Id;
        public string? VietnameseName;
        public string? EnglishName;
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
        public string? ImagePath;
        public bool Status;
        //public ICollection<Word>? Words;

    }
}
