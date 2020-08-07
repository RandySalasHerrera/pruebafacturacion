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
    public interface IFacturaRepository
    {
         Task<ObjectResult> GetFacturaList();
         Task<ObjectResult> GetFacturaById(string Id);
         Task<ObjectResult> Save(FacturaCreateViewModel Factura);
         Task<ObjectResult> Save(FacturaCreateViewModel Factura, string Id = null);
         Task<ObjectResult> Delete(string Id);
    }

    public class FacturaRepository : BaseRepository, IFacturaRepository
    {

              
        public async Task<ObjectResult> GetFacturaList()
        {
            try
            {
                var res = await getFacturaList();
                return await OResult.OkRequestTaskResult(res);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

         private async Task<dynamic> getFacturaList()
        {
            string spName = "dbo.Factura_Select";
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

         public async Task<ObjectResult> GetFacturaById(string id)
        {
            try
            {
                var res = await getFacturaById(id);
                return await OResult.OkRequestTaskResult(res);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

        private async Task<dynamic> getFacturaById(string id)
        {
            string spName = "dbo.FacturaById_Select";
            using (var conn = this.Connection)
            {
                using (GridReader ip = this.RunSPMultiple(conn, spName, new { Id = id }))
                {
                    dynamic data = ip.Read<dynamic>().SingleOrDefault();                   

                    return  data;
                }
            }

        }

        public async Task<ObjectResult> Save(FacturaCreateViewModel Factura)
        {
            try
            {
                var res = createFactura(Factura);
                string message = "Factura creado correctamente.";
                return await OResult.SuccessTaskResult(message);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

        private dynamic createFactura(FacturaCreateViewModel Factura)
        {
            string spName = "dbo.Factura_Save";
            var spParams = Factura.ToDynamic();
            using (var conn = this.Connection)
            {
                var response = this.RunSPQuerySingle<dynamic>(conn, spName, spParams);
                return response;
            }
        }

         public async Task<ObjectResult> Save(FacturaCreateViewModel Factura, string Id)
        {
            try
            {
                var res = updatePersona(Factura, Id);
                string message = "Factura actualizado correctamente.";
                return await OResult.SuccessTaskResult(message);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }
        
        private dynamic updatePersona(FacturaCreateViewModel Factura, string Id)
        {
            string spName = "dbo.Factura_Save";
            var spParams = Factura.ToDynamic(new { Id = Id });
            using (var conn = this.Connection)
            {
                var response = this.RunSPQuerySingle<dynamic>(conn, spName, spParams);
                return response;
            }
        }

         public async Task<ObjectResult> Delete(string Id)
        {
            try
            {
                var Persona = delete(Id);
                return await OResult.OkRequestTaskResult(Persona);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }
        private dynamic delete(string Id)
        {
            var spParams = new { Id = Id };
            string spName = "dbo.Factura_Delete";
            using (var conn = this.Connection)
            {
                var response = this.RunSPQuerySingle<dynamic>(conn, spName, spParams);
                return response;
            }
        }

        
    }
}