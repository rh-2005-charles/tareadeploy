using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ic_tienda_bussines.Dtos.Response
{
    public class ComprobanteResponse
    {
        [JsonPropertyName("errors")]
        public string Errors { get; set; }

        [JsonPropertyName("tipo")]
        public int Tipo { get; set; }

        [JsonPropertyName("serie")]
        public string Serie { get; set; }

        [JsonPropertyName("numero")]
        public int Numero { get; set; }

        [JsonPropertyName("enlace_del_pdf")]
        public string PdfUrl { get; set; }

        [JsonPropertyName("enlace_del_xml")]
        public string XmlUrl { get; set; }

        [JsonPropertyName("enlace_del_cdr")]
        public string CdrUrl { get; set; }

        [JsonPropertyName("aceptada_por_sunat")]
        public bool AceptadaSunat { get; set; }

        [JsonPropertyName("sunat_description")]
        public string SunatDescription { get; set; }

        [JsonPropertyName("sunat_note")]
        public string SunatNote { get; set; }

        [JsonPropertyName("sunat_responsecode")]
        public string SunatResponseCode { get; set; }

        [JsonPropertyName("codigo_hash")]
        public string CodigoHash { get; set; }
    }
}