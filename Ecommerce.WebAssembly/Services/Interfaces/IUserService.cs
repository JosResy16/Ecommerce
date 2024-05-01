using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Interfaces
{
    public interface IUserService
    {
        Task<RespuestaDTO<List<UsuarioDTO>>> Lista(string rol, string buscar);
        Task<RespuestaDTO<UsuarioDTO>> Obtener(int id);
        Task<RespuestaDTO<SesionDTO>> Autorizacion(LoginDTO modelo);
        Task<RespuestaDTO<UsuarioDTO>> Crear(UsuarioDTO modelo);
        Task<RespuestaDTO<bool>> Editar(UsuarioDTO modelo);
        Task<RespuestaDTO<bool>> Eliminar(int id);
    }
}
