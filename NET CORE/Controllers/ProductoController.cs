using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NET_CORE.Repository;
using NET_CORE.Views;

namespace NET_CORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoRepository Producto;
        public ProductoController(IProductoRepository Producto)
        {
            this.Producto = Producto;
        }

        // GET 
        [HttpGet]
         public async Task<ObjectResult> GetProductoList()
        {
            return await this.Producto.GetProductoList();
        }

         // GET 
        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetAsyncs(string id)
        {
            return await this.Producto.GetProductoById(id);
        }

        [HttpPost]
        public async Task<ObjectResult> Save([FromBody] ProductoCreateViewModel Producto)
        {
             return await this.Producto.Save(Producto);
        }

        [HttpPost("{Id}")]
        public async Task<ObjectResult> Save([FromBody] ProductoCreateViewModel Producto,string Id)
        {
             return await this.Producto.Save(Producto, Id);
        }

        
        [HttpDelete("{Id}")]
        public async Task<ActionResult<dynamic>> Delete(string Id)
        {
            return await this.Producto.Delete(Id);
        }

       
    }
}
