using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        IQueryable<TModel> Consultar(Expression<Func<TModel,bool>>? filtro= null);
        Task<TModel> Crear(TModel model);
        Task<bool> Editar(TModel model);
        Task<bool> Eliminar(TModel model);
    }
}
