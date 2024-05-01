using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Interfaces
{
    public interface IProductService
    {
        Task<RespuestaDTO<List<ProductoDTO>>> Lista(string buscar);
        Task<RespuestaDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar);
        Task<RespuestaDTO<ProductoDTO>> Obtener(int id);
        Task<RespuestaDTO<ProductoDTO>> Crear(ProductoDTO modelo);
        Task<RespuestaDTO<bool>> Editar(ProductoDTO modelo);
        Task<RespuestaDTO<bool>> Eliminar(int id);
    }
}
