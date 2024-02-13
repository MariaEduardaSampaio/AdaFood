using System.Text.RegularExpressions;

namespace AdaFood.Domain.ValueObjects
{
    public class Endereco
    {
        public string cep { get; set; }
        public int numero { get; set; }
        public Endereco(string cep, int numero)
        {
            ValidarEndereco(cep, numero);
        }

        public void ValidarEndereco(string cep, int numero)
        {
        }
    }
}
