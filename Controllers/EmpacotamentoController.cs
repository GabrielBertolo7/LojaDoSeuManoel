using LojaDoSeuManoel.Models;
using LojaDoSeuManoel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpacotamentoController : ControllerBase
    {
        private readonly IEmpacotadorService _empacotadorService;

        public EmpacotamentoController(IEmpacotadorService empacotadorService)
        {
            _empacotadorService = empacotadorService;
        }

        [HttpPost("empacotar")]
        public ActionResult<List<RespostaEmpacotamento>> EmpacotarPedidos([FromBody] List<Pedido> pedidos)
        {
            if (pedidos == null || pedidos.Count == 0)
                return BadRequest("Lista de pedidos está vazia.");

            var resultado = _empacotadorService.EmpacotarPedidos(pedidos);

            return Ok(resultado);
        }
    }
}
