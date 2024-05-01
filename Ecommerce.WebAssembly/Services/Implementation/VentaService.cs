using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Interfaces;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class VentaService : IVentaService
    {
        private readonly HttpClient _httpClient;

        public VentaService (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RespuestaDTO<List<VentaDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<List<VentaDTO>>>($"Venta/Lista/{buscar}");
        }

        public async Task<RespuestaDTO<VentaDTO>> Registrar(VentaDTO modelo)
        {
            var respuesta = await _httpClient.PostAsJsonAsync("Venta/Registrar", modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<VentaDTO>>();
            return resultado!;
        }
    }
}
