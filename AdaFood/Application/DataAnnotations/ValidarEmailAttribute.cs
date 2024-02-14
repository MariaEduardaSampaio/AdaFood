using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AdaFood.Application.DataAnnotations
{
    public class ValidarEmailAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult("O Email é obrigatório.");

            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(value.ToString(), emailPattern))
                return new ValidationResult("O Email não está no formato correto.");

            return ValidationResult.Success;
        }
    }
}
