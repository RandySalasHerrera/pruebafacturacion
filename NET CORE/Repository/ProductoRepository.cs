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
    public interface IProductoRepository
    {
         Task<ObjectResult> GetProductoList();
         Task<ObjectResult> GetProductoById(string Id);
         Task<ObjectResult> Save(ProductoCreateViewModel Producto);
         Task<ObjectResult> Save(ProductoCreateViewModel Producto, string Id = null);
         Task<ObjectResult> Delete(string Id);
    }

    public class ProductoRepository : BaseRepository, IProductoRepository
    {

              
        public async Task<ObjectResult> GetProductoList()
        {
            try
            {
                var res = await getProductoList();
                return await OResult.OkRequestTaskResult(res);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

         private async Task<dynamic> getProductoList()
        {
            string spName = "dbo.Producto_Select";
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

         public async Task<ObjectResult> GetProductoById(string id)
        {
            try
            {
                var res = await getProductoById(id);
                return await OResult.OkRequestTaskResult(res);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

        private async Task<dynamic> getProductoById(string id)
        {
            string spName = "dbo.ProductoById_Select";
            using (var conn = this.Connection)
            {
                using (GridReader ip = this.RunSPMultiple(conn, spName, new { Id = id }))
                {
                    dynamic data = ip.Read<dynamic>().SingleOrDefault();                   

                    return  data;
                }
            }

        }

        public async Task<ObjectResult> Save(ProductoCreateViewModel Producto)
        {
            try
            {
                var res = createProducto(Producto);
                string message = "Producto creado correctamente.";
                return await OResult.SuccessTaskResult(message);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }

        private dynamic createProducto(ProductoCreateViewModel Producto)
        {
            string spName = "dbo.Producto_Save";
            var spParams = Producto.ToDynamic();
            using (var conn = this.Connection)
            {
                var response = this.RunSPQuerySingle<dynamic>(conn, spName, spParams);
                return response;
            }
        }

         public async Task<ObjectResult> Save(ProductoCreateViewModel Producto, string Id)
        {
            try
            {
                var res = updatePersona(Producto, Id);
                string message = "Producto actualizado correctamente.";
                return await OResult.SuccessTaskResult(message);
            }
            catch (System.Exception ex)
            {
                return await OResult.BadRequestTaskResult(ex);
            }
        }
        
        private dynamic updatePersona(ProductoCreateViewModel Producto, string Id)
        {
            string spName = "dbo.Producto_Save";
            var spParams = Producto.ToDynamic(new { Id = Id });
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
            string spName = "dbo.Producto_Delete";
            using (var conn = this.Connection)
            {
                var response = this.RunSPQuerySingle<dynamic>(conn, spName, spParams);
                return response;
            }
        }

        
    }
}