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
    public class SaleDetailRepository : IRepositoryDetail<SaleDetail, Guid>
    {
        private SaleContext db;
        public SaleDetailRepository(SaleContext _db)
        {
            db = _db;
        }
        public SaleDetail Add(SaleDetail entity) 
        {
            //throw new NotImplementedException();
            db.SaleDetails.Add(entity);
            return entity;

        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }
    }


}
