using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Service.Interfaces;
using Ecommerce.DTO;
using Ecommerce.Service.Implementation;


namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("Resumen")]
        public IActionResult Resumen()
        {
            var respuesta = new RespuestaDTO<DashboardDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = _dashboardService.Resumen();
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }
    }
}
