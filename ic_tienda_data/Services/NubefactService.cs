using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using ic_tienda_bussines.Dtos.Request;
using ic_tienda_bussines.Dtos.Response;
using ic_tienda_bussines.Services;
using ic_tienda_data.Sources.Data.Models;
using Microsoft.Extensions.Configuration;

namespace ic_tienda_data.Services
{
    public class NubefactService : INubefactService
    {
        private readonly HttpClient _httpClient;
        private readonly NubefactConfig _config;

        public NubefactService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration.GetSection("Nubefact").Get<NubefactConfig>();

            // Configurar HttpClient
            _httpClient.BaseAddress = new Uri(_config.ApiUrl);
            // _httpClient.DefaultRequestHeaders.Add("Authorization", $"Token token={_config.ApiToken}");
        }

        public async Task<ComprobanteResponse> EmitirComprobante(ComprobanteRequest request)
        {
            try
            {
                // Configuración específica para pruebas
                request.EnviarSunat = false;
                request.EnviarCliente = false;
                request.Serie = "FFF1"; // Serie para pruebas

                // Calcular valores automáticamente
                foreach (var item in request.Items)
                {
                    item.Subtotal = item.ValorUnitario * item.Cantidad;
                    item.Igv = item.Subtotal * (request.PorcentajeIgv / 100);
                    item.Total = item.Subtotal + item.Igv;
                }

                request.TotalGravada = request.Items.Sum(i => i.Subtotal);
                request.TotalIgv = request.Items.Sum(i => i.Igv);
                request.Total = request.TotalGravada + request.TotalIgv;

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                    Converters = { new DateTimeConverter() }
                };

                var content = new StringContent(
                    JsonSerializer.Serialize(request, options),
                    Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.PostAsync("", content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return new ComprobanteResponse
                    {
                        Errors = $"Error al conectar con Nubefact: {response.StatusCode}. Detalles: {errorContent}"
                    };
                }

                return await response.Content.ReadFromJsonAsync<ComprobanteResponse>();
            }
            catch (Exception ex)
            {
                return new ComprobanteResponse
                {
                    Errors = $"Error al emitir comprobante: {ex.Message}"
                };
            }
        }

        // Clase auxiliar para formato de fecha
        public class DateTimeConverter : System.Text.Json.Serialization.JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return DateTime.Parse(reader.GetString());
            }

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
            }
        }
    }
}