using System;
using System.Collections.Generic;
using System.Text;

//id identificador único
namespace AppVenta.Dominio
{
    public class Product
    {
        public Guid productId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public decimal cost { get; set; }

        public decimal price { get; set; }

        public decimal amountInStock { get; set; }

        public List<SaleDetail> SaleDetails { get; set; }
    }
}
