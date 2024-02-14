using System.ComponentModel.DataAnnotations;

namespace AdaFood.Application.Requests
{
    public class CriarPedidoRequest
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Cep { get; set; }
        [Required]
        public int Numero { get; set; }
    }
}
