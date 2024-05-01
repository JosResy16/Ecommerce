using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Interfaces;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RespuestaDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<List<ProductoDTO>>>($"Product/Catalogo/{categoria}/{buscar}");
        }

        public async Task<RespuestaDTO<ProductoDTO>> Crear(ProductoDTO modelo)
        {
            var respuesta = await _httpClient.PostAsJsonAsync("Product/Crear", modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<ProductoDTO>>();
            return resultado!;
        }

        public async Task<RespuestaDTO<bool>> Editar(ProductoDTO modelo)
        {
            var respuesta = await _httpClient.PutAsJsonAsync("Product/Editar", modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<bool>>();
            return resultado!;
        }

        public async Task<RespuestaDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<RespuestaDTO<bool>>($"Product/Eliminar/{id}");
        }

        public async Task<RespuestaDTO<List<ProductoDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<List<ProductoDTO>>>($"Product/Lista/{buscar}");
        }

        public async Task<RespuestaDTO<ProductoDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<ProductoDTO>>($"Product/Obtener/{id}");
        }
    }
}
