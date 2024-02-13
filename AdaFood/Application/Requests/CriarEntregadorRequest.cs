using AdaFood.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace AdaFood.Application.Requests
{
    public class CriarEntregadorRequest
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public Email Email { get; set; }
        [Required]
        public CPF Cpf { get; set; }
        [Required]
        public Veiculo Veiculo { get; set; }
        public CriarEntregadorRequest(string nome, string email, string cpf, string tipoVeiculo, string? placaVeiculo)
        {
            Nome = nome;
            Email = new Email(email);
            Cpf = new CPF(cpf);
            Veiculo = new Veiculo(tipoVeiculo, placaVeiculo);
        }
    }
}
