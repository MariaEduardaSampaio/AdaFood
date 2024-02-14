using System.ComponentModel.DataAnnotations;

namespace AdaFood.Domain
{
    public class Pedido
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Cep {  get; set; }
        [Required]
        public int Numero { get; set; }

    }
}
