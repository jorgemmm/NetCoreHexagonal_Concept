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
    public class ProductController : ControllerBase
    {
        // Obetenemos Producservice por D.I.
        ProductService MakeService()
        {
            SaleContext db = new SaleContext();
            ProductRepository productRepo = new ProductRepository(db);
            ProductService service = new ProductService(productRepo);
            return service;
        }


        // GET: api/<ProductController>
        [HttpGet]
        //public IEnumerable<string> Get(){ //return new string[] { "value1", "value2" };}
        public ActionResult<List<Product>>Get()  //Retornamos una acción, que se genere una lista de de productos
        {            
            var service = MakeService();
            return Ok(service.Get()); // como consecuencia de obtener el listado ( si OK ) se produce la acción, el resultado 
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        //public string Get(int id) { return "value"; }
        public ActionResult<Product> Get( Guid id)  
        {
            var service = MakeService();
            return Ok(service.GetbyId(id)); 
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] Product producto)
        {
            var service = MakeService();
            service.Add(producto);

            return Ok(" Product Added successfully ");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Product producto)
        {
            var service = MakeService();
            service.Edit(producto);

            return Ok(" Product Edited successfully ");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var service = MakeService();
            service.Delete(id);

            return Ok(" Product delete successfully ");
        }
    }
}
