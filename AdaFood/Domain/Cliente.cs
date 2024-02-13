using AdaFood.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace AdaFood.Domain
{
    public class Cliente
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
        public Endereco Endereco { get; set; }
    }
}
