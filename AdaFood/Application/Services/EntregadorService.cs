using AdaFood.Application.Requests;
using AdaFood.Domain;
using AdaFood.Domain.Interfaces;
using System.Text.RegularExpressions;

namespace AdaFood.Application.Services
{
    public class EntregadorService: IEntregadorService
    {
        private static int contadorId;
        private readonly IEntregadorRepository<Entregador> _repository;

        public EntregadorService(IEntregadorRepository<Entregador> repository)
        {
            _repository = repository;
            contadorId = _repository.GetAll().Last().Id + 1;
        }

        public Entregador? CadastrarEntregador(CriarEntregadorRequest request)
        {
            string cpfNumerico = Regex.Replace(request.Cpf, @"\D", "");

            var entregador = new Entregador()
            {
                Email = request.Email,
                Cpf = cpfNumerico,
                Nome = request.Nome,
                Id = contadorId++,
                Pedidos = new()
            };
            _repository.Add(entregador);
            return entregador;
        }

        public IEnumerable<Entregador> PegarTodosEntregadores()
        {
            return (_repository.GetAll());
        }

        public Entregador? EncontrarEntregadorPorCPF(string cpf)
        {
            string cpfNumerico = Regex.Replace(cpf, @"\D", "");
            var entregador = _repository.GetByCPF(cpfNumerico);
            return entregador;
        }

        public Entregador? AtualizarEntregador(AtualizarEntregadorRequest request)
        {
            var entregadorAntigo = _repository.GetById(request.Id);
            if (entregadorAntigo == null)
                throw new Exception("Não existe um entregador com este ID.");

            var entregador = new Entregador()
            {
                Email = request.Email,
                Cpf = request.Cpf,
                Nome = request.Nome,
                Id = request.Id
            };
            _repository.Update(entregador);

            return entregador;
        }

        public Entregador? DeletarEntregador(int id)
        {
            var entregador = _repository.Delete(id);
            if (entregador == null)
                throw new Exception($"Não existe entregador de ID {id}.");

            return entregador;
        }

        public Entregador? AdicionarPedido(int id, CriarPedidoRequest request, Endereco endereco)
        {
            var entregador = _repository.GetById(id);
            endereco.number = request.Numero;

            if (entregador is not null)
            {
                var pedido = new Pedido()
                {
                    Descricao = request.Descricao,
                    Endereco = endereco
                };

                if (entregador.Pedidos is null)
                    entregador.Pedidos = new List<Pedido>(); 

                entregador.Pedidos.Add(pedido);
                _repository.Update(entregador);
            }

            return entregador;
        }
    }
}
