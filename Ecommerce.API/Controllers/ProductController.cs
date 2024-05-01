using Ecommerce.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.DTO;
using Ecommerce.Service.Implementation;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] ProductoDTO modelo)
        {
            var respuesta = new RespuestaDTO<ProductoDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _productService.Crear(modelo);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO modelo)
        {
            var respuesta = new RespuestaDTO<bool>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _productService.Editar(modelo);
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
                respuesta.Resultado = await _productService.Eliminar(id);
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
            var respuesta = new RespuestaDTO<List<ProductoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _productService.Lista(buscar);
            }
            catch (Exception ex)
            {
                respuesta.EsCorrecto = false;
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpGet("Catalogo/{categoria?}/{buscar?}")]
        public async Task<IActionResult> Catalogo(string categoria,string buscar = "NA")
        {
            var respuesta = new RespuestaDTO<List<ProductoDTO>>();

            try
            {
                if (categoria.ToLower() == "todos") categoria = "";
                if (buscar == "NA") buscar = "";

                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _productService.Catalogo(categoria,buscar);
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
            var respuesta = new RespuestaDTO<ProductoDTO>();

            try
            {
                respuesta.EsCorrecto = true;
                respuesta.Resultado = await _productService.Obtener(id);
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
