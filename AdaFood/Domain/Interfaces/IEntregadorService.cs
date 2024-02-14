using AdaFood.Application.Requests;

namespace AdaFood.Domain.Interfaces
{
    public interface IEntregadorService
    {
        Entregador? CadastrarEntregador(CriarEntregadorRequest request);
        Entregador? EncontrarEntregadorPorCPF(string cpf);
        IEnumerable<Entregador> PegarTodosEntregadores();
        Entregador? AtualizarEntregador(AtualizarEntregadorRequest request);
        Entregador? DeletarEntregador(int id);
        Entregador? AdicionarPedido(int id, CriarPedidoRequest request);

    }
}
