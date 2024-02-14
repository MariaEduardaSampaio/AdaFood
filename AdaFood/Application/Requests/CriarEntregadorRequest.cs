using AdaFood.Application.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace AdaFood.Application.Requests
{
    public class CriarEntregadorRequest
    {
        [Required]
        [MinLength(2), MaxLength(80)]
        public string Nome { get; set; }

        [ValidarEmail]
        public string Email { get; set; }

        [ValidarCPF]
        public string Cpf { get; set; }
    }
}
