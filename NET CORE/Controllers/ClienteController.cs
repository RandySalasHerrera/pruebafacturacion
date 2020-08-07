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
    public class ClienteController : ControllerBase
    {
        private IClienteRepository Cliente;
        public ClienteController(IClienteRepository Cliente)
        {
            this.Cliente = Cliente;
        }

        // GET 
        [HttpGet]
         public async Task<ObjectResult> GetClienteList()
        {
            return await this.Cliente.GetClienteList();
        }

         // GET 
        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetAsyncs(string id)
        {
            return await this.Cliente.GetClienteById(id);
        }

        [HttpPost]
        public async Task<ObjectResult> Save([FromBody] ClienteCreateViewModel cliente)
        {
             return await this.Cliente.Save(cliente);
        }

        [HttpPost("{Id}")]
        public async Task<ObjectResult> Save([FromBody] ClienteCreateViewModel cliente,string Id)
        {
             return await this.Cliente.Save(cliente, Id);
        }

        
        [HttpDelete("{Id}")]
        public async Task<ActionResult<dynamic>> Delete(string Id)
        {
            return await this.Cliente.Delete(Id);
        }

       
    }
}
