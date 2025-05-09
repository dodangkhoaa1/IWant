#nullable enable
[System.Serializable]
public class UserResponseDTO
{
    public string UserId;
    public string FullName;
    public string Email;
    public bool EmailConfirmed;
    public bool? Gender;
    public string? ChildName;
    public string? ChildNickName;
    public bool? ChildGender;
    public bool? Status;
}
