using AdaFood.Domain;
using AdaFood.Domain.Interfaces;

namespace AdaFood.Repository
{
    public class ClienteRepository: IRepository<Cliente>
    {
        private static List<Cliente> Clientes = new List<Cliente>();

        public void Add(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public void Delete(int id)
        {
            var cliente = Clientes.FirstOrDefault(e => e.Id.Equals(id));
            if (cliente != null)
                Clientes.Remove(cliente);
            else
                Console.WriteLine($"Não existe cliente de ID {id}.");
        }

        public Cliente? GetById(int id)
        {
            var cliente = Clientes.FirstOrDefault(e => e.Id.Equals(id));
            return cliente;
        }

        public void Update(Cliente cliente)
        {
            var clienteAntigo = Clientes.FirstOrDefault(e => e.Id.Equals(cliente.Id));
            if (clienteAntigo != null)
            {
                Clientes.Remove(clienteAntigo);
                Clientes.Add(cliente);
                Clientes.OrderBy(e => e.Id);
            }
            else
                Console.WriteLine($"Não existe cliente de ID {cliente.Id}.");
        }
    }
}
