using AdaFood.Domain;
using AdaFood.Domain.Interfaces;
using System.Text.RegularExpressions;

namespace AdaFood.Repository
{
    public class EntregadorRepository : IEntregadorRepository<Entregador>
    {
        private static List<Entregador> Entregadores = new List<Entregador>();

        public void Add(Entregador entregador)
        {
            Entregadores.Add(entregador);
        }

        public Entregador? Delete(int id)
        {
            var entregador = Entregadores.FirstOrDefault(e => e.Id.Equals(id));

            if (entregador != null)
                Entregadores.Remove(entregador);

            return entregador;
        }

        public IEnumerable<Entregador> GetAll()
        {
            return Entregadores;
        }

        public Entregador? GetById(int id)
        {
            var entregador = Entregadores.FirstOrDefault(e => e.Id.Equals(id));
            return entregador;
        }

        public Entregador? GetByCPF(string cpf)
        {
            var entregador = Entregadores.FirstOrDefault(e => e.Cpf.Equals(cpf));
            return entregador;
        }

        public void Update(Entregador entregador)
        {
            var entregadorAntigo = Entregadores.FirstOrDefault(e => e.Id.Equals(entregador.Id));
            entregador.Cpf = Regex.Replace(entregador.Cpf, @"\D", "");

            if (entregadorAntigo != null)
            {
                Entregadores.Remove(entregadorAntigo);
                Entregadores.Add(entregador);
                Entregadores = Entregadores.OrderBy(e => e.Id).ToList();
            }
            else
                Console.WriteLine($"Não existe entregador de ID {entregador.Id}.");
        }
    }
}
