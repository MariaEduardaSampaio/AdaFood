using AdaFood.Domain;
using AdaFood.Domain.Interfaces;

namespace AdaFood.Repository
{
    public class EntregadorRepository : IRepository<Entregador>
    {
        private static List<Entregador> Entregadores = new List<Entregador>();

        public void Add(Entregador entregador)
        {
            Entregadores.Add(entregador);
        }

        public void Delete(int id)
        {
            var entregador = Entregadores.FirstOrDefault(e => e.Id.Equals(id));
            if (entregador != null)
                Entregadores.Remove(entregador);
            else
                Console.WriteLine($"Não existe entregador de ID {id}.");
        }

        public Entregador? GetById(int id)
        {
            var entregador = Entregadores.FirstOrDefault(e => e.Id.Equals(id));
            return entregador;
        }

        public void Update(Entregador entregador)
        {
            var entregadorAntigo = Entregadores.FirstOrDefault(e => e.Id.Equals(entregador.Id));
            if (entregadorAntigo != null)
            {
                Entregadores.Remove(entregadorAntigo);
                Entregadores.Add(entregador);
                Entregadores.OrderBy(e => e.Id);
            }
            else
                Console.WriteLine($"Não existe entregador de ID {entregador.Id}.");
        }
    }
}
