using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjetoDBServer.API.Command;
using ProjetoDBServer.Application.Interfaces;

namespace ProjetoDBServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        public readonly IContaCorrenteAppService _contaCorrenteAppService;

        public BancoController(IContaCorrenteAppService contaCorrenteAppService)
        {
            _contaCorrenteAppService = contaCorrenteAppService;
        }

        // POST: api/Banco
        [HttpPost]
        public IActionResult Transferencia([FromBody]TransferenciaCommand transferencia)
        {
            try
            {
                var retorno = _contaCorrenteAppService.Transferencia(transferencia.ContaOrigem, transferencia.ContaDestino, transferencia.Valor);

                if (retorno != "Transferência efetuada com sucesso!")
                    return BadRequest(retorno);

                return Ok(retorno);
            }
            catch
            {
                return StatusCode(500);
            }

            
        }
    }
}
