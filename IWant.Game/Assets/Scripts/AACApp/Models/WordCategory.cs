using System;
#nullable enable
namespace Assets.Scripts.AACApp.Models
{
    [Serializable]
    public class WordCategory
    {
        public int id;
        public string? nameEn;
        public string nameVi;
        public DateTime createdAt;
        public DateTime updatedAt;
        public string? imagePath;
        public bool status;
        //public ICollection<Word>? Words;

    }
}
