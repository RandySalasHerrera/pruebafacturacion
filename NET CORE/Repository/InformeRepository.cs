using System.Linq;
using System.Threading.Tasks;
using EPublico.Core.Extensions;
using EPublico.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using NET_CORE.Helpers;
using NET_CORE.Views;
using static Dapper.SqlMapper;

namespace NET_CORE.Repository
{
    public interface IInformeRepository
    {
         Task<ObjectResult> GetListClientesNoMayores();
         Task<ObjectResult> GetListClientesUltimaCompra();
         Task<ObjectResult> GetListAlertaProducto();
         Task<ObjectResult> GetValorVendidoProducto();
        
    }

    public class InformeRepository : BaseRepository, IInformeRepository
    {

              
        public async Task<ObjectResult> GetListClientesNoMayores()
        {
            try
            {
                var res = await getListClientesNoMayores();
                return await OResult.OkRequestTaskResult(res);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

         private async Task<dynamic> getListClientesNoMayores()
        {
            string spName = "dbo.Lista_Clientes_NO_Mayores";
            dynamic spParams = new { };
            using (var conn = this.Connection)
            {
                using (GridReader ip =  this.RunSPMultiple(conn, spName, spParams))
                {
                    var response = ip.Read<dynamic>();
                    return response;
                }
            }

        }


        public async Task<ObjectResult> GetListClientesUltimaCompra()
        {
            try
            {
                var res = await getListClientesUltimaCompra();
                return await OResult.OkRequestTaskResult(res);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

         private async Task<dynamic> getListClientesUltimaCompra()
        {
            string spName = "dbo.Lista_Clientes_Ultima_Compra";
            dynamic spParams = new { };
            using (var conn = this.Connection)
            {
                using (GridReader ip =  this.RunSPMultiple(conn, spName, spParams))
                {
                    var response = ip.Read<dynamic>();
                    return response;
                }
            }

        }

          public async Task<ObjectResult> GetListAlertaProducto()
        {
            try
            {
                var res = await getListAlertaProducto();
                return await OResult.OkRequestTaskResult(res);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

         private async Task<dynamic> getListAlertaProducto()
        {
            string spName = "dbo.Producto_Lista_minimo_cinco";
            dynamic spParams = new { };
            using (var conn = this.Connection)
            {
                using (GridReader ip =  this.RunSPMultiple(conn, spName, spParams))
                {
                    var response = ip.Read<dynamic>();
                    return response;
                }
            }

        }

          public async Task<ObjectResult> GetValorVendidoProducto()
        {
            try
            {
                var res = await getValorVendidoProducto();
                return await OResult.OkRequestTaskResult(res);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

         private async Task<dynamic> getValorVendidoProducto()
        {
            string spName = "dbo.Valor_Vendido_Producto";
            dynamic spParams = new { };
            using (var conn = this.Connection)
            {
                using (GridReader ip =  this.RunSPMultiple(conn, spName, spParams))
                {
                    var response = ip.Read<dynamic>();
                    return response;
                }
            }

        }

        
    }
}