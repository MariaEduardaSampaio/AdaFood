using AdaFood.Application.Requests;
using AdaFood.Domain;
using AdaFood.Domain.Interfaces;

namespace AdaFood.Application.Services
{
    public class EntregadorService: IEntregadorService
    {
        private static int contadorId = 0;
        private readonly IRepository<Entregador> _repository;
        public EntregadorService(IRepository<Entregador> repository)
        {
            _repository = repository;
        }
        public Entregador CadastrarEntregador(CriarEntregadorRequest request)
        {
            var entregador = new Entregador(contadorId++, request.Nome, request.Email, request.Cpf, request.Veiculo);
            _repository.Add(entregador);
            return entregador;
        }
    }
}
