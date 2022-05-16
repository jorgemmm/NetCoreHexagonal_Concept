using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio
{
    public class Sale
    {
        public Guid saleId { get; set; }

        public long saleNumber { get; set; } //code

        public DateTime saleDate { get; set; }

        public string concept { get; set; }

        public decimal subtotal { get; set; }

        public decimal tax { get; set; }

        public decimal total { get; set; }

        public List<SaleDetail> SaleDetails { get; set; }

    }
}
