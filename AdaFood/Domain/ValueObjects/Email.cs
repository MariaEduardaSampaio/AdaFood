using System.Text.RegularExpressions;

namespace AdaFood.Domain.ValueObjects
{
    public class Email
    {
        public string email { get; set; }
        public Email(string email)
        {
            ValidarEmail(email);
        }

        public void ValidarEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,}$";

            if (Regex.IsMatch(email, pattern))
                this.email = email;
            else
                throw new Exception("Email não é válido.");
        }
    }
}
