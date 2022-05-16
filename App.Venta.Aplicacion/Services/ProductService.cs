using System;
using System.Collections.Generic;
using System.Text;

using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces_CRUD.Repositories;
using App.Venta.Aplicacion.Interfaces;

namespace App.Venta.Aplicacion.Services
{
    //Lógica independiente de la tecnología 
    public class ProductService : IServicioBase<Product, Guid>
    {
        public Product Add(Product entidad)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid entidad)
        {
            throw new NotImplementedException();
        }

        public void Edit(Product entidad)
        {
            throw new NotImplementedException();
        }

        public List<Product> Get()
        {
            throw new NotImplementedException();
        }

        public Product GetbyId(Guid entidadId)
        {
            throw new NotImplementedException();
        }
    }
}
