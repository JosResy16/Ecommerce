using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Service.Interfaces;
using Ecommerce.DTO;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Lista/{rol:alpha}/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string rol, string buscar = "NA")
        {
            var respuesta = new RespuestaDTO<List<UsuarioDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _userService.Lista(rol, buscar);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpGet("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var respuesta = new RespuestaDTO<UsuarioDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _userService.Obtener(id);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] UsuarioDTO modelo)
        {
            var respuesta = new RespuestaDTO<UsuarioDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _userService.Crear(modelo);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost("Autorizacion")]
        public async Task<IActionResult> Autorizacion([FromBody] LoginDTO modelo)
        {
            var respuesta = new RespuestaDTO<SesionDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _userService.Autorizacion(modelo);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO modelo)
        {
            var respuesta = new RespuestaDTO<bool>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _userService.Editar(modelo);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpDelete("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuesta = new RespuestaDTO<bool>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _userService.Eliminar(id);
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
