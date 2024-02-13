using AdaFood.Application.Requests;
using AdaFood.Domain;
using AdaFood.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdaFood.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntregadorController : Controller
    {
        private readonly IEntregadorService _service;
        public EntregadorController(IEntregadorService service)
        {
            _service = service;
        }

        [HttpPost("CadastrarEntregador", Name = "Cadastrar entregador")]
        public IActionResult CadastrarEntregador([FromBody] CriarEntregadorRequest request)
        {
            try
            {
                var entregador = _service.CadastrarEntregador(request);
                return Ok(entregador);
            } catch (Exception ex)
            {
                return BadRequest($"Não foi possível cadastrar um entregador: {ex}");
            }
        }
    }
}
