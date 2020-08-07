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
    public class InformeController : ControllerBase
    {
        private IInformeRepository Informe;
        public InformeController(IInformeRepository Informe)
        {
            this.Informe = Informe;
        }

        [HttpGet("clientesnomayores")]
         public async Task<ObjectResult> GetListClientesNoMayores()
        {
            return await this.Informe.GetListClientesNoMayores();
        }

        [HttpGet("clientesultimacompra")]
         public async Task<ObjectResult> GetListClientesUltimaCompra()
        {
            return await this.Informe.GetListClientesUltimaCompra();
        }

        [HttpGet("alertaproducto")]
         public async Task<ObjectResult> GetListAlertaProducto()
        {
            return await this.Informe.GetListAlertaProducto();
        }

        [HttpGet("valorvendidoproducto")]
         public async Task<ObjectResult> GetValorVendidoProducto()
        {
            return await this.Informe.GetValorVendidoProducto();
        }

    }
}
