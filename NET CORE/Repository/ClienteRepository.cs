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
    public interface IClienteRepository
    {
         Task<ObjectResult> GetClienteList();
         Task<ObjectResult> GetClienteById(string Id);
         Task<ObjectResult> Save(ClienteCreateViewModel cliente);
         Task<ObjectResult> Save(ClienteCreateViewModel cliente, string Id = null);
         Task<ObjectResult> Delete(string Id);
    }

    public class ClienteRepository : BaseRepository, IClienteRepository
    {

              
        public async Task<ObjectResult> GetClienteList()
        {
            try
            {
                var res = await getClienteList();
                return await OResult.OkRequestTaskResult(res);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

         private async Task<dynamic> getClienteList()
        {
            string spName = "dbo.Cliente_Select";
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

         public async Task<ObjectResult> GetClienteById(string id)
        {
            try
            {
                var res = await getClienteById(id);
                return await OResult.OkRequestTaskResult(res);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

        private async Task<dynamic> getClienteById(string id)
        {
            string spName = "dbo.ClienteById_Select";
            using (var conn = this.Connection)
            {
                using (GridReader ip = this.RunSPMultiple(conn, spName, new { Id = id }))
                {
                    dynamic data = ip.Read<dynamic>().SingleOrDefault();                   

                    return  data;
                }
            }

        }

        public async Task<ObjectResult> Save(ClienteCreateViewModel cliente)
        {
            try
            {
                var res = createCliente(cliente);
                string message = "Cliente creado correctamente.";
                return await OResult.SuccessTaskResult(message);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

        private dynamic createCliente(ClienteCreateViewModel cliente)
        {
            string spName = "dbo.Cliente_Save";
            var spParams = cliente.ToDynamic();
            using (var conn = this.Connection)
            {
                var response = this.RunSPQuerySingle<dynamic>(conn, spName, spParams);
                return response;
            }
        }

         public async Task<ObjectResult> Save(ClienteCreateViewModel cliente, string Id)
        {
            try
            {
                var res = updatePersona(cliente, Id);
                string message = "Cliente actualizado correctamente.";
                return await OResult.SuccessTaskResult(message);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }
        
        private dynamic updatePersona(ClienteCreateViewModel cliente, string Id)
        {
            string spName = "dbo.Cliente_Save";
            var spParams = cliente.ToDynamic(new { Id = Id });
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
            string spName = "dbo.Cliente_Delete";
            using (var conn = this.Connection)
            {
                var response = this.RunSPQuerySingle<dynamic>(conn, spName, spParams);
                return response;
            }
        }

        
    }
}