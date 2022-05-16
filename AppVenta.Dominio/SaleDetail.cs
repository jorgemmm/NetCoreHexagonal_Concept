using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio
{
    public class SaleDetail
    {
        public Guid productId { get; set; }
        public Guid SaleId { get; set; }

        public decimal unitCost { get; set; }

        public decimal unitPrice { get; set; }

        public decimal amountSaled { get; set; }

        public decimal subtotal { get; set; }

        public decimal tax { get; set; }

        public decimal total { get; set; }

        public Product Product { get; set; }

        public Sale Sale { get; set; }


    }
}
