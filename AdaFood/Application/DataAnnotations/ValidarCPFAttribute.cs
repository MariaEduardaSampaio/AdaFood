using System.ComponentModel.DataAnnotations;

namespace AdaFood.Application.DataAnnotations
{
    public class ValidarCPFAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult("O CPF é obrigatório.");

            string cpf = value.ToString().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return new ValidationResult("O CPF deve ter 11 dígitos.");

            return ValidationResult.Success;
        }
    }
}
