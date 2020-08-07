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
    public interface IDetalleRepository
    {
         Task<ObjectResult> GetDetalleList();
         Task<ObjectResult> GetDetalleById(string Id);
         Task<ObjectResult> Save(DetalleCreateViewModel Detalle);
         Task<ObjectResult> Save(DetalleCreateViewModel Detalle, string Id = null);
         Task<ObjectResult> Delete(string Id);
    }

    public class DetalleRepository : BaseRepository, IDetalleRepository
    {

              
        public async Task<ObjectResult> GetDetalleList()
        {
            try
            {
                var res = await getDetalleList();
                return await OResult.OkRequestTaskResult(res);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

         private async Task<dynamic> getDetalleList()
        {
            string spName = "dbo.Detalle_Select";
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

         public async Task<ObjectResult> GetDetalleById(string id)
        {
            try
            {
                var res = await getDetalleById(id);
                return await OResult.OkRequestTaskResult(res);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

        private async Task<dynamic> getDetalleById(string id)
        {
            string spName = "dbo.DetalleById_Select";
            using (var conn = this.Connection)
            {
                using (GridReader ip = this.RunSPMultiple(conn, spName, new { Id = id }))
                {
                    dynamic data = ip.Read<dynamic>().SingleOrDefault();                   

                    return  data;
                }
            }

        }

        public async Task<ObjectResult> Save(DetalleCreateViewModel Detalle)
        {
            try
            {
                var res = createDetalle(Detalle);
                string message = "Detalle creado correctamente.";
                return await OResult.SuccessTaskResult(message);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

        private dynamic createDetalle(DetalleCreateViewModel Detalle)
        {
            string spName = "dbo.Detalle_Save";
            var spParams = Detalle.ToDynamic();
            using (var conn = this.Connection)
            {
                var response = this.RunSPQuerySingle<dynamic>(conn, spName, spParams);
                return response;
            }
        }

         public async Task<ObjectResult> Save(DetalleCreateViewModel Detalle, string Id)
        {
            try
            {
                var res = updatePersona(Detalle, Id);
                string message = "Detalle actualizado correctamente.";
                return await OResult.SuccessTaskResult(message);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }
        
        private dynamic updatePersona(DetalleCreateViewModel Detalle, string Id)
        {
            string spName = "dbo.Detalle_Save";
            var spParams = Detalle.ToDynamic(new { Id = Id });
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
            string spName = "dbo.Detalle_Delete";
            using (var conn = this.Connection)
            {
                var response = this.RunSPQuerySingle<dynamic>(conn, spName, spParams);
                return response;
            }
        }

        
    }
}