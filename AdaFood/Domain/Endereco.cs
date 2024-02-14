using System.Text.Json;

namespace AdaFood.Domain
{
    public class Endereco
    {
        public string cep { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string neighborhood { get; set; }
        public string street { get; set; }
        public string service { get; set; }
        public int? number { get; set; }
    }
}
