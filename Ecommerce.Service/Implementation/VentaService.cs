using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Ecommerce.DTO;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interfaces;
using AutoMapper;
using Ecommerce.Models;

namespace Ecommerce.Service.Implementation
{
    public class VentaService : IVentaService
    {
        private readonly IMapper _mapper;
        private readonly IVentaRepository _ventaRepository;

        public VentaService(IMapper mapper, IVentaRepository ventaRepository)
        {
            _mapper = mapper;
            _ventaRepository = ventaRepository; 
        }

        public async Task<VentaDTO> Registrar(VentaDTO modelo)
        {
            try
            {
                var dbModel = _mapper.Map<Venta>(modelo);
                var ventaGenerada = await _ventaRepository.Registrar(dbModel);

                if (ventaGenerada.IdVenta != 0)
                    return _mapper.Map<VentaDTO>(ventaGenerada);
                else
                    throw new TaskCanceledException("No se pudo registar");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<VentaDTO>> Lista(string buscar)
        {
            try
            {
                List<VentaDTO> lista = new List<VentaDTO>();

                var consulta = _ventaRepository.Consultar(e => e.IdUsuarioNavigation != null && 
                e.IdUsuarioNavigation.NombreCompleto.ToLower().Contains(buscar.ToLower()));

                if(consulta != null)
                    lista = _mapper.Map<List<VentaDTO>> (await consulta.ToListAsync());

                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
