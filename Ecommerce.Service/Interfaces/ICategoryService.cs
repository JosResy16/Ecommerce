using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.DTO;

namespace Ecommerce.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoriaDTO>> Lista(string buscar);
        Task<CategoriaDTO> Obtener(int id);
        Task<CategoriaDTO> Crear(CategoriaDTO modelo);
        Task<bool> Editar(CategoriaDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
