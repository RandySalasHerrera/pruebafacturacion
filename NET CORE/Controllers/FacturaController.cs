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
    public class FacturaController : ControllerBase
    {
        private IFacturaRepository Factura;
        public FacturaController(IFacturaRepository Factura)
        {
            this.Factura = Factura;
        }

        // GET 
        [HttpGet]
         public async Task<ObjectResult> GetFacturaList()
        {
            return await this.Factura.GetFacturaList();
        }

         // GET 
        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetAsyncs(string id)
        {
            return await this.Factura.GetFacturaById(id);
        }

        [HttpPost]
        public async Task<ObjectResult> Save([FromBody] FacturaCreateViewModel Factura)
        {
             return await this.Factura.Save(Factura);
        }

        [HttpPost("{Id}")]
        public async Task<ObjectResult> Save([FromBody] FacturaCreateViewModel Factura,string Id)
        {
             return await this.Factura.Save(Factura, Id);
        }

        
        [HttpDelete("{Id}")]
        public async Task<ActionResult<dynamic>> Delete(string Id)
        {
            return await this.Factura.Delete(Id);
        }

       
    }
}
