namespace IWant.API.Data.DTOs
{
    public class SigninResponseDTO
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed{ get; set; }
        public bool? Gender { get; set; }
        public string? ChildName { get; set; }
        public string? ChildNickName { get; set; }
        public bool? ChildGender { get; set; }
        public bool? Status { get; set; }
    }
}
