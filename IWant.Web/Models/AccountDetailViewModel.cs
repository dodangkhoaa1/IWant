namespace IWant.Web.Models
{
    public class AccountDetailViewModel
    {
        //Parent information
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? ImageUrl { get; set; }
        public DateOnly Birthday { get; set; }
        public bool? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? Status { get; set; }

        //Child information
        public string? ChildName { get; set; }
        public string? ChildNickName { get; set; }
        public DateOnly ChildBirthday { get; set; }
        public bool? ChildGender { get; set; }

        //Another information
        public int TotalBlogs { get; set; } = 0;
        public int TotalComments { get; set; } = 0;
        public int TotalRates { get; set; } = 0;
    }
}
