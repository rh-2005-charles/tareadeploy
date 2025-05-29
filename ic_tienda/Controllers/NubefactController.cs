using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ic_tienda_bussines.Dtos.Request;
using ic_tienda_bussines.Services;
using Microsoft.AspNetCore.Mvc;

namespace ic_tienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NubefactController : ControllerBase
    {
        private readonly INubefactService _nubefactService;

        public NubefactController(INubefactService nubefactService)
        {
            _nubefactService = nubefactService;
        }

        [HttpPost("emitir-comprobante")]
        public async Task<IActionResult> EmitirComprobante([FromBody] ComprobanteRequest request)
        {
            var response = await _nubefactService.EmitirComprobante(request);

            if (!string.IsNullOrEmpty(response.Errors))
                return BadRequest(response);

            return Ok(response);
        }
    }
}