using System.ComponentModel.DataAnnotations;

namespace IWant.Web
{
    public class ValidBirthdayAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateOnly birthday)
            {
                var today = new DateOnly(DateTime.Today.Year, 1, 1);
                var minDate = today.AddYears(-100);
                var maxDate = today.AddYears(-6); 

                if (birthday < minDate || birthday > maxDate)
                {
                    return new ValidationResult($"Birthday must be from {minDate.ToString("MM/dd/yyyy")} to {maxDate.ToString("MM/dd/yyyy")}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}