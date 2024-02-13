using System.Text.RegularExpressions;

namespace AdaFood.Domain.ValueObjects
{
    public class CPF
    {
        public string Cpf { get; set; }
        public CPF(string cpf)
        {
            ValidarCPF(cpf);
        }
        public void ValidarCPF(string cpf)
        {
            string cpfNumerico = Regex.Replace(cpf, @"\D", "");

            if (cpf.Length == 11)
                Cpf = cpfNumerico;
            else
                throw new Exception("CPF não é válido.");
        }
    }
}
