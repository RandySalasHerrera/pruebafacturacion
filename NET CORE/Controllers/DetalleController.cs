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
    public class DetalleController : ControllerBase
    {
        private IDetalleRepository Detalle;
        public DetalleController(IDetalleRepository Detalle)
        {
            this.Detalle = Detalle;
        }

        // GET 
        [HttpGet]
         public async Task<ObjectResult> GetDetalleList()
        {
            return await this.Detalle.GetDetalleList();
        }

         // GET 
        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetAsyncs(string id)
        {
            return await this.Detalle.GetDetalleById(id);
        }

        [HttpPost]
        public async Task<ObjectResult> Save([FromBody] DetalleCreateViewModel Detalle)
        {
             return await this.Detalle.Save(Detalle);
        }

        [HttpPost("{Id}")]
        public async Task<ObjectResult> Save([FromBody] DetalleCreateViewModel Detalle,string Id)
        {
             return await this.Detalle.Save(Detalle, Id);
        }

        
        [HttpDelete("{Id}")]
        public async Task<ActionResult<dynamic>> Delete(string Id)
        {
            return await this.Detalle.Delete(Id);
        }

       
    }
}
