using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.Service.Interfaces;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Models;
using Ecommerce.DTO;
using AutoMapper;
using Azure.Core;

namespace Ecommerce.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Producto> _modelRepository;

        public ProductService(IMapper mapper, IGenericRepository<Producto> modelRepository)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;
        }

        public async Task<ProductoDTO> Crear(ProductoDTO modelo)
        {
            try
            {
                var dbModel = _mapper.Map<Producto>(modelo);
                var respModelo = await _modelRepository.Crear(dbModel);

                if (respModelo.IdProducto != 0)
                    return _mapper.Map<ProductoDTO>(respModelo);
                else
                    throw new TaskCanceledException("No se pudo crear");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(ProductoDTO modelo)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p => p.IdProducto == modelo.IdProducto);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.Nombre = modelo.Nombre;
                    fromDbModel.Descripcion = modelo.Descripcion;
                    fromDbModel.IdCategoria = modelo.IdCategoria;
                    fromDbModel.Precio = modelo.Precio;
                    fromDbModel.PrecioOferta = modelo.PrecioOferta;
                    fromDbModel.Cantidad = modelo.Cantidad;
                    fromDbModel.Imagen = modelo.Imagen;
                    var respuesta = await _modelRepository.Editar(fromDbModel);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo editat");
                    return respuesta;
                }
                else
                    throw new TaskCanceledException("No se encontraron coincdencias");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p => p.IdProducto == id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    var respuesta = await _modelRepository.Eliminar(fromDbModel);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo eliminar");
                    return respuesta;
                }
                else
                    throw new TaskCanceledException("No se encontraron coincidenias");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductoDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower()));

                consulta = consulta.Include(c => c.IdCategoriaNavigation);

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductoDTO>> Catalogo(string categoria, string buscar)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p =>
                    p.Nombre.ToLower().Contains(buscar.ToLower()) &&
                    p.IdCategoriaNavigation.Nombre.ToLower().Contains(categoria.ToLower())
                );

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p => p.IdProducto == id);
                consulta = consulta.Include(c => c.IdCategoriaNavigation);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                    return _mapper.Map<ProductoDTO>(fromDbModel);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
