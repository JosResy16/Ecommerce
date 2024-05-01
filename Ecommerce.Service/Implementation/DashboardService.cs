using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Implementation
{
    public class DashboardService :IDashboardService
    {
        private readonly IGenericRepository<Producto> _productoRepositorio;
        private readonly IGenericRepository<Usuario> _usuarioRepositorio;
        private readonly IVentaRepository _ventaRepositorio;

        public DashboardService(
            IGenericRepository<Producto> productoRepositorio,
            IGenericRepository<Usuario> usuarioRepositorio,
            IVentaRepository ventaRepositorio
            )
        {
            _productoRepositorio = productoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _ventaRepositorio = ventaRepositorio;
        }

        private string Ingresos()
        {
            var consulta = _ventaRepositorio.Consultar();
            decimal? ingresos = consulta.Sum( x => x.Total );
            return Convert.ToString(ingresos);
        }

        private int Ventas()
        {
            var consulta = _ventaRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }

        private int Clientes()
        {
            var consulta = _usuarioRepositorio.Consultar(u=> u.Rol.ToLower() == "cliente");
            int total = consulta.Count();
            return total;
        }

        private int Productos()
        {
            var consulta = _productoRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }

        public DashboardDTO Resumen()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO()
                {
                    TotalIngresos = Ingresos(),
                    TotalVenta = Ventas(),
                    TotalCliente = Clientes(),
                    TotalProducto = Productos()
                };
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
