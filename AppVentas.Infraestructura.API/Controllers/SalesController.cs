using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Dominio
using AppVenta.Dominio;

//Aplicacion servicios
using AppVenta.Aplicacion.Services;

//Contexts DB y Repo´s
using AppVentas.Infraestructura.Datos.Contextos;
using AppVentas.Infraestructura.Datos.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppVentas.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {

        SaleServices MakeService()
        {
            SaleContext db = new SaleContext();
            SaleRepository saleRepo = new SaleRepository(db);
            ProductRepository productRepo = new ProductRepository(db);
            SaleDetailRepository detailRepo = new SaleDetailRepository(db);
            SaleServices service = new SaleServices(saleRepo,productRepo, detailRepo);
            return service;
        }

        // GET: api/<SalesController>
        [HttpGet]
        //public IEnumerable<string> Get() return new string[] { "value1", "value2" };
        public ActionResult<List<Product>> Get()  
        {
            //Retornamos el reultado de una acción Get method
            
            var service = MakeService();
            return Ok(service.Get()); 
        }



        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public ActionResult<Sale> Get(Guid id)
        {
            var service = MakeService();
            return Ok(service.GetbyId(id));
        }

        // POST api/<SalesController>
        [HttpPost]
        public ActionResult Post([FromBody] Sale sale)
        {
            var service = MakeService();
            service.Add(sale);

            return Ok(" sale Added successfully ");
        }

       //no put method, no edit method in sales

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var service = MakeService();
            service.Refound(id);

            return Ok(" sale delete successfully ");
        }
    }
}
