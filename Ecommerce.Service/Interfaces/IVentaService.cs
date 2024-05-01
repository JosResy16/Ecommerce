using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.DTO;

namespace Ecommerce.Service.Interfaces
{
    public interface IVentaService
    {
        Task<VentaDTO> Registrar(VentaDTO modelo);
        Task<List<VentaDTO>> Lista(string buscar);
    }
}
