using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Interfaces
{
    public interface IVentaService
    {
        Task<RespuestaDTO<VentaDTO>> Registrar(VentaDTO modelo);
        Task<RespuestaDTO<List<VentaDTO>>> Lista(string buscar);
    }
}
