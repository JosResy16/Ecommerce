using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.Repository.Interfaces;
using Ecommerce.Repository.DBContext;
using Ecommerce.Models;
using System.Linq.Expressions;

namespace Ecommerce.Repository.Implementation
{
    public  class VentaRepository : GenericRepository<Venta> , IVentaRepository
    {
        private readonly DbecommerceContext _dbContext;
        public VentaRepository(DbecommerceContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Registrar(Venta model)
        {
            Venta ventaGenerada = new Venta();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleVenta db in model.DetalleVenta)
                    {
                        Producto producto_econtrado = _dbContext.Productos.Where(p=> p.IdProducto == db.IdProducto).First();
                        producto_econtrado.Cantidad -= db.Cantidad; //resta y actualiza el stock
                        _dbContext.Productos.Update(producto_econtrado);
                    }
                    await _dbContext.SaveChangesAsync();

                    await _dbContext.Venta.AddAsync(model); //agrega la venta ala tabla
                    await _dbContext.SaveChangesAsync();

                    ventaGenerada = model;
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return ventaGenerada;
        }

    }
}
