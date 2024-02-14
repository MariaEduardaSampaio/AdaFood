using AdaFood.Application.Filters;
using AdaFood.Application.Requests;
using AdaFood.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace AdaFood.Application.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class EntregadorController : Controller
    {
        private readonly IEntregadorService _service;
        private readonly IHttpClientFactory _httpClientFactory;

        public EntregadorController(IEntregadorService service, IHttpClientFactory httpClientFactory)
        {
            _service = service;
            _httpClientFactory = httpClientFactory;

        }

        [ServiceFilter(typeof(CustomAuthoritazionFilter))]
        [HttpPost("CadastrarEntregador", Name = "Cadastrar entregador")]
        public IActionResult CadastrarEntregador([FromBody] CriarEntregadorRequest request, [FromQuery] bool erro)
        {
            if (erro)
                throw new Exception("Deu um erro muito feio que não pode ser visto pelo cliente.");
            var entregador = _service.CadastrarEntregador(request);
            return Ok(entregador);
        }

        [HttpGet("PegarTodosEntregadores", Name = "Pegar todos os entregadores")]
        public IActionResult PegarTodosEntregadores()
        {
            return Ok(_service.PegarTodosEntregadores());
        }

        [HttpGet("Entregador/{cpf}", Name = "Pegar entregador por CPF")]
        public IActionResult PegarEntregadorPorCPF([FromRoute] string cpf)
        {
            var entregador = _service.EncontrarEntregadorPorCPF(cpf);
            return Ok(entregador);
        }

        [HttpPut("AtualizarEntregador", Name = "Atualizar entregador")]
        public IActionResult AtualizarEntregador([FromBody] AtualizarEntregadorRequest request)
        {
            var entregadorAtualizado = _service.AtualizarEntregador(request);
            return Ok(entregadorAtualizado);
        }

        [ServiceFilter(typeof(CustomAuthoritazionFilter))]
        [HttpDelete("DeletarEntregador/{id}", Name = "Deletar entregador")]
        public IActionResult DeletarEntregador([FromRoute] int id)
        {
            var entregadorDeletado = _service.DeletarEntregador(id);
            return Ok(entregadorDeletado);
        }

        [HttpGet("AdicionarPedido/{id}")]
        public async Task<IActionResult> AdicionarPedido([FromRoute] int id, [FromBody] CriarPedidoRequest request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"https://brasilapi.com.br/api/cep/v1/{request.Cep}");

                if (!response.IsSuccessStatusCode)
                    return BadRequest("Erro ao consultar o CEP.");

                var entregador = _service.AdicionarPedido(id, request);
                return Ok(entregador);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
