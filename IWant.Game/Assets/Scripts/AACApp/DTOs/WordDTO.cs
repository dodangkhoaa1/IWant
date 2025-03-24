using LootLocker.Extension.DataTypes;
using System;

#nullable enable
[Serializable]
public class WordDTO
{
    public int Id;
    public string? VietnameseText;
    public string? EnglishText;
    public DateTime CreatedAt;
    public DateTime UpdatedAt;
    public string? ImagePath;
    public bool Status;
    public int? WordCategoryId;
    public WordCategoryDTO? WordCategory;
    public string UserId;
    public User? User;
    public byte[]? Image;

}

