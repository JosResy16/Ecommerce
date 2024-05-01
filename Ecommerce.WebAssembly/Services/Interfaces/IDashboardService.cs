using Ecommerce.DTO;
namespace Ecommerce.WebAssembly.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<RespuestaDTO<DashboardDTO>> Resumen();
    }
}
