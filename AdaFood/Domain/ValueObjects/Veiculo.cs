using AdaFood.Domain.Enums;
using System.Text.RegularExpressions;

namespace AdaFood.Domain.ValueObjects
{
    public class Veiculo
    {
        public TipoVeiculo TipoVeiculo { get; set; }
        public string? Placa { get; set; }
        public Veiculo(string tipoVeiculo, string? placa = null)
        {
            ValidarVeiculo(tipoVeiculo, placa);
        }

        public void ValidarVeiculo(string tipoVeiculo, string? placa = null)
        {
            if (Enum.TryParse(tipoVeiculo, true, out TipoVeiculo TipoVeiculo))
                this.TipoVeiculo = TipoVeiculo;
            else
                throw new ArgumentException("Tipo de veículo inválido.");

            string pattern = @"^[A-Z]{3}\-\d{4}$";

            if (Regex.IsMatch(placa, pattern))
                Placa = placa;
            else 
                throw new ArgumentException("Placa de veículo inválida.");
        }
    }
}
