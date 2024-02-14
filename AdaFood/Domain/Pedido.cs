using System.ComponentModel.DataAnnotations;

namespace AdaFood.Domain
{
    public class Pedido
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public Endereco Endereco {  get; set; }
    }
}
