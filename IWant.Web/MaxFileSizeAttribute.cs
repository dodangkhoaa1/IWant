using System.ComponentModel.DataAnnotations;

namespace IWant.Web
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;

        public MaxFileSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file && file.Length > _maxSize)
            {
                return new ValidationResult($"Maximum allowed file size is {_maxSize / (1024 * 1024)} MB.");
            }
            return ValidationResult.Success;
        }
    }
}