using AdaFood.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace AdaFood.Domain
{
    public class Entregador
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public Email Email { get; set; }
        [Required]
        public CPF Cpf { get; set; }
        [Required]
        public Veiculo Veiculo { get; set; }
        public Entregador(int id, string nome, Email email, CPF cpf, Veiculo veiculo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Veiculo = veiculo;
        }
    }
}
