using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Service.Interfaces;
using Ecommerce.DTO;
using Ecommerce.Service.Implementation;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var respuesta = new RespuestaDTO<List<CategoriaDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _categoryService.Lista(buscar);
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
            var respuesta = new RespuestaDTO<CategoriaDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _categoryService.Obtener(id);
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
                respuesta.Resultado = await _categoryService.Eliminar(id);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] CategoriaDTO model)
        {
            var respuesta = new RespuestaDTO<bool>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _categoryService.Editar(model);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] CategoriaDTO model)
        {
            var respuesta = new RespuestaDTO<CategoriaDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _categoryService.Crear(model);
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
