using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Interfaces;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RespuestaDTO<SesionDTO>> Autorizacion(LoginDTO modelo)
        {
            var respuesta = await _httpClient.PostAsJsonAsync("User/Autorizacion",modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<SesionDTO>>();
            return resultado!;
        }

        public async Task<RespuestaDTO<UsuarioDTO>> Crear(UsuarioDTO modelo)
        {
            var respuesta = await _httpClient.PostAsJsonAsync("User/Crear", modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<UsuarioDTO>>();
            return resultado!;
        }

        public async Task<RespuestaDTO<bool>> Editar(UsuarioDTO modelo)
        {
            var respuesta = await _httpClient.PutAsJsonAsync("User/Editar", modelo);
            var resultado = await respuesta.Content.ReadFromJsonAsync<RespuestaDTO<bool>>();
            return resultado!;
        }

        public async Task<RespuestaDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<RespuestaDTO<bool>>($"User/Eliminar/{id}");
            
        }

        public async Task<RespuestaDTO<List<UsuarioDTO>>> Lista(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<List<UsuarioDTO>>>($"User/Lista/{rol}/{buscar}");
        }

        public async Task<RespuestaDTO<UsuarioDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<RespuestaDTO<UsuarioDTO>>($"User/Obtener/{id}");
        }
    }
}
