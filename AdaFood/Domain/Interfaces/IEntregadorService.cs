using AdaFood.Application.Requests;

namespace AdaFood.Domain.Interfaces
{
    public interface IEntregadorService
    {
        Entregador CadastrarEntregador(CriarEntregadorRequest request);
    }
}
