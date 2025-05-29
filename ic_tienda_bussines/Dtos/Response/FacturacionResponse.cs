using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ic_tienda_bussines.Dtos.Response
{
    public class FacturacionResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string EnlacePdf { get; set; }
        public string EnlaceXml { get; set; }
        public string EnlaceCdr { get; set; }
    }
}