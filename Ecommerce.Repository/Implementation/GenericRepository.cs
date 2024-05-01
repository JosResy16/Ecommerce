using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.Repository.Interfaces;
using Ecommerce.Repository.DBContext;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository.Implementation
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly DbecommerceContext _dbContext;
        public GenericRepository(DbecommerceContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public IQueryable<TModel> Consultar(Expression<Func<TModel, bool>>? filtro = null)
        {
            IQueryable<TModel> consulta = (filtro == null) ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(filtro);
            return consulta;
        }

        public async Task<TModel> Crear(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            } catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
