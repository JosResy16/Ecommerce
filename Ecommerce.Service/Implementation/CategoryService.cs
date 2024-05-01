using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.Service.Interfaces;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Models;
using Ecommerce.DTO;
using AutoMapper;

namespace Ecommerce.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Categoria> _modelRepository;

        public CategoryService(IMapper mapper, IGenericRepository<Categoria> modelRepository)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;
        }

        public async Task<CategoriaDTO> Crear(CategoriaDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Categoria>(modelo);
                var rspModelo = await _modelRepository.Crear(dbModelo);

                if (rspModelo.IdCategoria != 0)
                    return _mapper.Map<CategoriaDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se pudo crear");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(CategoriaDTO modelo)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p => p.IdCategoria == modelo.IdCategoria);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.Nombre = modelo.Nombre;
                    var respuesta = await _modelRepository.Editar(fromDbModel);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo editar");
                    return respuesta;
                }
                else
                    throw new TaskCanceledException("No se encontraron resultados");
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
                var consulta = _modelRepository.Consultar(p => p.IdCategoria == id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    var respuesta = await _modelRepository.Eliminar(fromDbModel);
                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo eliminar");
                    return respuesta;
                }
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");
            }
            catch(Exception ex) 
            { 
                throw ex;
            }
        }

        public async Task<List<CategoriaDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p =>
                    p.Nombre!.ToLower().Contains(buscar.ToLower())
                );

                List<CategoriaDTO> lista = _mapper.Map<List<CategoriaDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p=> p.IdCategoria == id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                    return _mapper.Map<CategoriaDTO>(fromDbModel);
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
