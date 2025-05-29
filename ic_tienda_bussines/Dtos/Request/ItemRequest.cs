using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ic_tienda_bussines.Dtos.Request
{
    public class ItemRequest
    {
        [JsonPropertyName("unidad_de_medida")]
        public string UnidadMedida { get; set; } = "NIU";

        [JsonPropertyName("codigo")]
        public string Codigo { get; set; } = "P001";

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("cantidad")]
        public decimal Cantidad { get; set; }

        [JsonPropertyName("valor_unitario")]
        public decimal ValorUnitario { get; set; }

        [JsonPropertyName("precio_unitario")]
        public decimal PrecioUnitario { get; set; }

        [JsonPropertyName("subtotal")] // CAMPO NUEVO OBLIGATORIO
        public decimal Subtotal { get; set; }

        [JsonPropertyName("tipo_de_igv")]
        public int TipoIgv { get; set; } = 1; // 1=Gravado

        [JsonPropertyName("igv")]
        public decimal Igv { get; set; }

        [JsonPropertyName("total")]
        public decimal Total { get; set; }
    }
}