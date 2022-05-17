using System;
using System.Collections.Generic;
using System.Text;

using AppVenta.Dominio;
using AppVenta.Dominio.Interfaces_CRUD.Repositories;
using AppVenta.Aplicacion.Interfaces;


namespace AppVenta.Aplicacion.Services
{
    
    

    public class SaleServices : IMovementService<Sale, Guid>
    {
        const int IVA = 14;

        private readonly IRepositoryMovement<Sale, Guid> repoSale;        
        private readonly IRepositoryBase<Product, Guid> repoProduct;
        private readonly IRepositoryDetail<SaleDetail, Guid> repoDetail;

        public SaleServices(IRepositoryMovement<Sale, Guid> _repoSale,
                            IRepositoryBase<Product, Guid>  _repoProduct,
                            IRepositoryDetail<SaleDetail, Guid> _repoDetail

            )
        {
            // Recogemos el repositorio a través de ctor; desconocemos la tecnología.
            repoSale = _repoSale;
            repoProduct = _repoProduct;
            repoDetail = _repoDetail;
        }

        public Sale Add(Sale entity)
        {
            if (entity == null)
                throw new NotImplementedException(" sale entity is requirement ");

            var SaleAdded = repoSale.Add(entity);

            entity.SaleDetails.ForEach(detail =>
           {
               var selectedProduct = repoProduct.GetbyId(detail.productId);
               if (selectedProduct == null)               
                   throw new NotImplementedException(" You can´t sale it; this product does no exit ");

               var newDetail = new SaleDetail();
               newDetail.saleId = SaleAdded.saleId;
               newDetail.productId = detail.productId;
               newDetail.unitCost = selectedProduct.cost;
               newDetail.unitPrice = selectedProduct.price;
               newDetail.amountSaled = detail.amountSaled;
               newDetail.subtotal = newDetail.unitPrice * newDetail.amountSaled;
               newDetail.tax = newDetail.subtotal * IVA / 100;
               newDetail.total = newDetail.subtotal + newDetail.tax;
               repoDetail.Add(newDetail);

               selectedProduct.amountInStock -= newDetail.amountSaled;
               repoProduct.Edit(selectedProduct);

               entity.subtotal += newDetail.subtotal;
               entity.tax += newDetail.tax;
               entity.total += newDetail.total;
               


           });

            
            repoSale.SaveAllChanges();

            return entity;
        }

        public void Refound(Guid entityId)
        {
            //throw new NotImplementedException();
            repoSale.Refound(entityId);
            repoSale.SaveAllChanges();
        }

        public List<Sale> Get()
        {
            //throw new NotImplementedException();
            return repoSale.Get();
        }

        public Sale GetbyId(Guid entityId)
        {
            //throw new NotImplementedException();
            return repoSale.GetbyId(entityId);
        }
    }
}
