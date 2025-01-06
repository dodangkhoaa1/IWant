using System;

#nullable enable
[Serializable]
public class WordCategoryDTO
{
    public int Id;
    public string? VietnameseName;
    public string? EnglishName;
    public DateTime CreatedAt;
    public DateTime UpdatedAt;
    public string? ImagePath;
    public bool Status;
    public byte[]? Image;
}
