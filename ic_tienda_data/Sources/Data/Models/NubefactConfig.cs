using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ic_tienda_data.Sources.Data.Models
{
    /*  public class NubefactConfig
     {
         public string ApiUrl { get; set; }
         public string ApiToken { get; set; }
         public string EmisorRuc { get; set; }
         public int EmisorTipoDocumento { get; set; }
     } */

    public class NubefactConfig
    {
        public string ApiUrl { get; set; }
        public string ApiToken { get; set; }
        public string NumeroDocumentoEmisor { get; set; }
        public string TipoDocumentoEmisor { get; set; }
    }
}