using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ic_tienda_bussines.Dtos.Request
{
    public class FacturacionRequest
    {
        public string Serie { get; set; }
        public int Numero { get; set; }
        public DateTime FechaEmision { get; set; }
        public string TipoDocumento { get; set; } // 01=Factura, 03=Boleta
        public int Moneda { get; set; } // PEN=Soles

        public ClienteDto Cliente { get; set; }
        public List<ItemDto> Items { get; set; }

        public decimal TotalGravada { get; set; }
        public decimal TotalIgv { get; set; }
        public decimal Total { get; set; }

        public string Observaciones { get; set; }
    }

    public class ClienteDto
    {
        public string TipoDocumento { get; set; } // 6=RUC, 1=DNI
        public string NumeroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

    }

    public class ItemDto
    {
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string TipoIgv { get; set; } // 10=Gravado
        public decimal Igv { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}