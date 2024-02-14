using AdaFood.Application.DataAnnotations;
using AdaFood.Domain;
using System.ComponentModel.DataAnnotations;

namespace AdaFood.Application.Requests
{
    public class AtualizarEntregadorRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(80)]
        public string Nome { get; set; }

        [ValidarEmail]
        public string Email { get; set; }

        [ValidarCPF]
        public string Cpf { get; set; }

        [Required]
        public List<Pedido>? Pedidos { get; set; }
    }
}
