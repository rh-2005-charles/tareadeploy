using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ic_tienda_bussines.Dtos.Request;
using ic_tienda_bussines.Dtos.Response;
using ic_tienda_bussines.Services;
using Microsoft.AspNetCore.Mvc;

namespace ic_tienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturacionController : ControllerBase
    {
        private readonly IFacturacionElectronicaService _facturacionService;
        public FacturacionController(IFacturacionElectronicaService facturacionService)
        {
            _facturacionService = facturacionService;
        }

        [HttpPost("emitir-factura")]
        public async Task<ActionResult<FacturacionResponse>> EmitirFactura([FromBody] FacturacionRequest request)
        {
            var result = await _facturacionService.EmitirFacturaElectronica(request);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}