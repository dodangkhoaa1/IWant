using System;
#nullable enable
namespace Assets.Scripts.AACApp.Models
{
    [Serializable]
    public class Word
    {
        public int id;
        public string? textEn;
        public string textVi;
        public DateTime createdAt;
        public DateTime updatedAt;
        public string? imagePath;
        public bool status;
        public int? wordCategoryId;
        public WordCategory? wordCategory;
    }
}
