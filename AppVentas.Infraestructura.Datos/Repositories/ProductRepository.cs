using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces_CRUD.Repositories;
using AppVentas.Infraestructura.Datos.Contextos;

//db contexto data base

namespace AppVentas.Infraestructura.Datos.Repositories
{
    public class ProductRepository : IRepositoryBase<Product, Guid>
    {
        private SaleContext db;

        public ProductRepository( SaleContext _db )
        {
            db = _db;
        }

        public Product Add(Product entity)
        {
            //throw new NotImplementedException();
            entity.productId = Guid.NewGuid();            
            db.Products.Add(entity);            
            return entity;


        }
        
        public void Delete(Guid entityId)
        {
            var selectedProduct = db.Products
               .Where(
                prod => prod.productId == entityId)
               .FirstOrDefault();
            if (selectedProduct != null)
            {
                db.Products.Remove(selectedProduct);

            }
            else 
            {
                throw new NullReferenceException(" Delete not posible; the product does not exit  ");
            }
        }

        public void Edit(Product entity)
        {

            var selectedProduct = db.Products
                .Where(
                 prod => prod.productId == entity.productId)
                .FirstOrDefault();
            if(selectedProduct!=null)
            {
                selectedProduct.name = entity.name;
                selectedProduct.description = entity.description;
                selectedProduct.cost = entity.cost;
                selectedProduct.price = entity.price;
                selectedProduct.amountInStock = entity.amountInStock;

                db.Entry(selectedProduct).State = EntityState.Modified;//Microsoft.EntityFrameworkCore.EntityState.Modified;


            }
            else
            {
                throw new NullReferenceException(" Edit not posible; the product does not exit  ");
            }
        }

        public List<Product> Get()
        {
                      
            return db.Products.ToList();
        }

        public Product GetbyId(Guid entityId)
        {
            var selectedProduct = db.Products
               .Where(
                prod => prod.productId == entityId)
               .FirstOrDefault();
            if (selectedProduct != null)
            {
                return selectedProduct;
            }
            else
            {
                throw new NullReferenceException( " No se puede obtener GET ese Id para el producto " );
            }
               
        }

        public void SaveAllChanges()
        {
            //throw new NotImplementedException();
            db.SaveChanges();
        }
    }
}
