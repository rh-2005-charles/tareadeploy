using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ic_tienda_bussines.Dtos.Request;
using ic_tienda_bussines.Dtos.Response;

namespace ic_tienda_bussines.Services
{
    public interface INubefactService
    {
        Task<ComprobanteResponse> EmitirComprobante(ComprobanteRequest request);
    }
}