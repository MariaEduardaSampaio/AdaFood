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
        public string Email { get; set; }

        [Required]
        public string Cpf { get; set; }

        public List<Pedido>? Pedidos { get; set; } = new();

    }
}
