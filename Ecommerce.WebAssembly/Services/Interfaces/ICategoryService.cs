using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<RespuestaDTO<List<CategoriaDTO>>> Lista(string buscar);
        Task<RespuestaDTO<CategoriaDTO>> Obtener(int id);
        Task<RespuestaDTO<CategoriaDTO>> Crear(CategoriaDTO modelo);
        Task<RespuestaDTO<bool>> Editar(CategoriaDTO modelo);
        Task<RespuestaDTO<bool>> Eliminar(int id);
    }
}
