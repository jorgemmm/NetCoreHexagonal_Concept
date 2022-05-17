using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces_CRUD.Repositories;
using AppVentas.Infraestructura.Datos.Contextos;

namespace AppVentas.Infraestructura.Datos.Repositories
{
    public class SaleRepository : IRepositoryMovement<Sale, Guid>
    {
        private SaleContext db;

        public SaleRepository(SaleContext _db)
        {
            db = _db;
        }

        public Sale Add(Sale entity)
        {
            //throw new NotImplementedException();
            entity.saleId = Guid.NewGuid();
            db.Sales.Add(entity);
            return entity;            

        }

        public void Refound(Guid entidadId)
        {
            
            var selectedSale = db.Sales
                .Where(sale => sale.saleId == entidadId)
                .FirstOrDefault();

            if(selectedSale==null)
                throw new NullReferenceException(" Delete not posible, EnitityId does NOT exit ");
            selectedSale.isRefounded = true;
            db.Entry(selectedSale).State = EntityState.Modified;

        }

        public List<Sale> Get()
        {
            return db.Sales.ToList();
        }

        public Sale GetbyId(Guid entityId)
        {
            //throw new NotImplementedException();
            var selectedSale = db.Sales
               .Where(
                sale => sale.saleId == entityId)
               .FirstOrDefault();
            if (selectedSale != null)
            {
                return selectedSale;
            }
            else
            {
                throw new NullReferenceException(" No se puede obtener GET ese Id para la venta ");
            }
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();

        }
    }
}
