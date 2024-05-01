using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Service.Interfaces;
using Ecommerce.DTO;


namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO modelo)
        {
            var respuesta = new RespuestaDTO<VentaDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _ventaService.Registrar(modelo);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var respuesta = new RespuestaDTO<List<VentaDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _ventaService.Lista(buscar);
            }
            catch (Exception ex)
            {
               respuesta.EsCorrecto= false;
               respuesta.Mensaje= ex.Message;
            
            }

            return Ok(respuesta);
        }
    }
}
