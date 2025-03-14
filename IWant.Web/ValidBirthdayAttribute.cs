using System.ComponentModel.DataAnnotations;

namespace IWant.Web
{
    public class ValidBirthdayAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateOnly birthday)
            {
                var today = DateOnly.FromDateTime(DateTime.Today);
                var minDate = today.AddYears(-100);
                var maxDate = today.AddYears(-6); 

                if (birthday < minDate || birthday > maxDate)
                {
                    return new ValidationResult($"Birthday must be from {minDate.Year} to {maxDate.Year}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}