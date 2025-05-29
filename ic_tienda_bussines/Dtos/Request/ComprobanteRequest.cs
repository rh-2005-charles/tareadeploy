using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ic_tienda_bussines.Dtos.Request
{
    public class ComprobanteRequest
    {
        [JsonPropertyName("operacion")]
        public string Operacion { get; set; } = "generar_comprobante";

        [JsonPropertyName("tipo_de_comprobante")]
        public int TipoComprobante { get; set; } // 1=Factura, 2=Boleta

        [JsonPropertyName("serie")]
        public string Serie { get; set; } = "FFF1"; // Serie para pruebas

        [JsonPropertyName("numero")]
        public int Numero { get; set; }

        [JsonPropertyName("sunat_transaction")]
        public int SunatTransaction { get; set; } = 1; // 1=Venta interna

        [JsonPropertyName("cliente_tipo_de_documento")]
        public int ClienteTipoDocumento { get; set; } // 6=RUC, 1=DNI

        [JsonPropertyName("cliente_numero_de_documento")]
        public string ClienteNumeroDocumento { get; set; }

        [JsonPropertyName("cliente_denominacion")]
        public string ClienteDenominacion { get; set; }

        [JsonPropertyName("cliente_direccion")]
        public string ClienteDireccion { get; set; }

        [JsonPropertyName("cliente_email")]
        public string ClienteEmail { get; set; }

        [JsonPropertyName("fecha_de_emision")]
        public DateTime FechaEmision { get; set; } = DateTime.Now;

        [JsonPropertyName("moneda")]
        public int Moneda { get; set; } = 1; // 1=Soles

        [JsonPropertyName("porcentaje_de_igv")]
        public decimal PorcentajeIgv { get; set; } = 18.00m;

        [JsonPropertyName("total_gravada")]
        public decimal TotalGravada { get; set; }

        [JsonPropertyName("total_igv")]
        public decimal TotalIgv { get; set; }

        [JsonPropertyName("total")]
        public decimal Total { get; set; }

        [JsonPropertyName("enviar_automaticamente_a_la_sunat")]
        public bool EnviarSunat { get; set; } = false; // False para pruebas

        [JsonPropertyName("enviar_automaticamente_al_cliente")]
        public bool EnviarCliente { get; set; } = false;

        [JsonPropertyName("items")]
        public List<ItemRequest> Items { get; set; }
    }
}