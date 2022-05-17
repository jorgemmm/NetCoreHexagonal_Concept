using System;
using System.Collections.Generic;
using System.Text;

using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces_CRUD.Repositories;
using AppVenta.Aplicacion.Interfaces;
//using AppVenta.Dominio.Interfaces_CRUD.Repositorios;


//Maybe this service in domain Layer?

namespace AppVenta.Aplicacion.Services
{
    //Lógica independiente de la tecnología 
    public class ProductService : IServicioBase<Product, Guid>
    {
        private readonly IRepositoryBase<Product, Guid> repoProduct;

        public ProductService(IRepositoryBase<Product, Guid> _repoProduct)
        {
            repoProduct = _repoProduct;
        }
        public Product Add(Product entity)
        {
            if(entity == null)
            throw new NotImplementedException(" Product is requirement ");

            var resultProduct = repoProduct.Add(entity);
            repoProduct.SaveAllChanges();

            return resultProduct;
        }

        public void Delete(Guid entity)
        {

            if (entity == null)
                throw new NotImplementedException(" Product is requirement to edit");

            repoProduct.Delete(entity);
            repoProduct.SaveAllChanges();


        }

        public void Edit(Product entity)
        {
            if(entity == null)
                throw new NotImplementedException(" Product is requirement to edit");

            repoProduct.Edit(entity);
            repoProduct.SaveAllChanges();
        }

        public List<Product> Get()
        {
           
           return repoProduct.Get();
        }

        public Product GetbyId(Guid entityId)
        {
            return repoProduct.GetbyId(entityId);

        }
    }
}
