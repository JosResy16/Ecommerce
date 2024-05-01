using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Interfaces;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class DashboardService : IDashboardService
    {
        private readonly HttpClient _httpClient;

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RespuestaDTO<DashboardDTO>> Resumen()
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<DashboardDTO>>($"Dashboard/Resumen");
        }
    }
}
