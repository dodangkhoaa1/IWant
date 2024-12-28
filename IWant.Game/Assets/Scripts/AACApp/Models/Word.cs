using System;
#nullable enable
namespace Assets.Scripts.AACApp.Models
{
    [Serializable]
    public class Word
    {
        public int Id;
        public string? VietnameseText;
        public string? EnglishText;
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
        public string? ImagePath;
        public bool Status;
        public int? WordCategoryId;
        public WordCategory? WordCategory;
    }
}
