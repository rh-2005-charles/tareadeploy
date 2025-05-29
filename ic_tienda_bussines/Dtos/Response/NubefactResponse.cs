using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ic_tienda_bussines.Dtos.Response
{
    public class NubefactResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Enlace_del_pdf { get; set; }
        public string Enlace_del_xml { get; set; }
        public string Enlace_del_cdr { get; set; }
        public string Codigo { get; set; }
    }
}