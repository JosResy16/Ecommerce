using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Interfaces;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {

            _httpClient = httpClient;   
        }

        public async Task<RespuestaDTO<CategoriaDTO>> Crear(CategoriaDTO modelo)
        {
            var respuesta = await _httpClient.PostAsJsonAsync("Category/Crear", modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<CategoriaDTO>>();
            return resultado!;
        }

        public async Task<RespuestaDTO<bool>> Editar(CategoriaDTO modelo)
        {
            var respuesta = await _httpClient.PutAsJsonAsync("Category/Editar", modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<bool>>();
            return resultado!;
        }

        public async Task<RespuestaDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<RespuestaDTO<bool>>($"Category/Eliminar/{id}");
        }

        public async Task<RespuestaDTO<List<CategoriaDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<List<CategoriaDTO>>>($"Category/Lista/{buscar}");
        }

        public async Task<RespuestaDTO<CategoriaDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<CategoriaDTO>>($"Category/Obtener/{id}");
        }
    }
}
