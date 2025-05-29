using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ic_tienda_bussines.Dtos.Request;
using ic_tienda_bussines.Dtos.Response;
using ic_tienda_bussines.Services;
using ic_tienda_data.Sources.Data.Models;
using Microsoft.Extensions.Configuration;

namespace ic_tienda_data.Services
{
    public class FacturacionElectronicaService : IFacturacionElectronicaService
    {
        private readonly HttpClient _httpClient;
        private readonly NubefactConfig _config;

        public FacturacionElectronicaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration.GetSection("Nubefact").Get<NubefactConfig>();

            // Configurar HttpClient
            _httpClient.BaseAddress = new Uri(_config.ApiUrl.TrimEnd('/') + "/");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Token token={_config.ApiToken}");
        }

        public async Task<FacturacionResponse> EmitirFacturaElectronica(FacturacionRequest request)
        {
            try
            {
                var nubefactRequest = new
                {
                    operacion = "generar_comprobante",
                    tipo_de_comprobante = request.TipoDocumento,
                    serie = "FFF1",
                    numero = request.Numero,
                    sunat_transaction = 1,
                    cliente_tipo_de_documento = request.Cliente.TipoDocumento,
                    cliente_numero_de_documento = request.Cliente.NumeroDocumento,
                    cliente_denominacion = request.Cliente.RazonSocial,
                    cliente_direccion = request.Cliente.Direccion,
                    cliente_email = request.Cliente.Email,
                    fecha_de_emision = DateTime.Now.ToString("yyyy-MM-dd"),
                    moneda = "PEN",
                    porcentaje_de_igv = 18.00m,
                    total_gravada = request.TotalGravada,
                    total_igv = request.TotalIgv,
                    total = request.Total,
                    items = request.Items.Select(i => new
                    {
                        unidad_de_medida = "NIU",
                        codigo = "P001",
                        descripcion = i.Descripcion,
                        cantidad = i.Cantidad,
                        valor_unitario = i.ValorUnitario,
                        precio_unitario = i.PrecioUnitario,
                        tipo_de_igv = i.TipoIgv,
                        igv = i.Igv,
                        subtotal = i.Subtotal,
                        total = i.Total,
                        codigo_tributo = "1000"
                    }).ToArray(),
                    observaciones = request.Observaciones,
                    enviar_automaticamente_a_la_sunat = false, // IMPORTANTE para pruebas
                    enviar_automaticamente_al_cliente = false
                };

                var content = new StringContent(
                    JsonSerializer.Serialize(nubefactRequest),
                    Encoding.UTF8, "application/json"
                );

                var response = await _httpClient.PostAsync("", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return new FacturacionResponse
                    {
                        Success = false,
                        Message = $"Error al conectar con Nubefact: {response.StatusCode}. Detalles: {errorContent}"
                    };
                }

                var nubefactResponse = await response.Content.ReadFromJsonAsync<NubefactResponse>();

                return new FacturacionResponse
                {
                    Success = nubefactResponse.Success,
                    Message = nubefactResponse.Message,
                    EnlacePdf = nubefactResponse.Enlace_del_pdf,
                    EnlaceXml = nubefactResponse.Enlace_del_xml,
                    EnlaceCdr = nubefactResponse.Enlace_del_cdr
                };
            }
            catch (Exception ex)
            {
                return new FacturacionResponse
                {
                    Success = false,
                    Message = $"Error al emitir factura electrónica: {ex.Message}"
                };
            }
        }
    }
}