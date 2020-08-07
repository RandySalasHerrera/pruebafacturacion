using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using static Dapper.SqlMapper;

namespace NET_CORE.Helpers
{
    public class BaseRepository : IDisposable
    {

        private readonly string _sqlConnection;

        public BaseRepository()
        {
            // var builder = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json");

            // var root = builder.Build();
            // _sqlConnection = root.GetConnectionString("DefaultConnection");
            _sqlConnection = "Server=localhost\\SQLEXPRESS;Database=facturacion_dev;Trusted_Connection=True;";

        }

        protected string SqlDataConnection
        {
            get => _sqlConnection;
        }

        public IDbConnection Connection
        {
            get
            {
                var conn = new SqlConnection(_sqlConnection);
                conn.Open();
                return conn;
            }
        }

        protected IDbConnection BuildConnection(string cx)
        {
            var conn = new SqlConnection(cx);
            conn.Open();
            return conn;
        }

        protected SqlConnection SqlConnection
        {
            get => new SqlConnection(_sqlConnection);
        }

        public dynamic RunSPQuerySingle<T>(IDbConnection conn, string spName, object parameters)
        {

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.AddDynamicParams(parameters);

            var data = conn.QuerySingleOrDefault<T>(
                spName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure);

            if (conn.State != ConnectionState.Closed)
                conn.Close();

            return data;
        }

        public async Task<T> RunSPQuerySingleAsync<T>(IDbConnection conn, string spName, object parameters)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.AddDynamicParams(parameters);

            var data = await conn.QuerySingleOrDefaultAsync<T>(
                spName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure);

            if (conn.State != ConnectionState.Closed)
                conn.Close();

            return data;

        }

        protected async Task<GridReader> RunQueryMultipleAsync(string rawSql, object parameters)
        {
            var conn = this.Connection;
            conn.Open();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.AddDynamicParams(parameters);
            var result = await conn.QueryMultipleAsync(

                rawSql,
                dynamicParameters,
                null,
                null,
                commandType: CommandType.Text
            );

            if (conn.State != ConnectionState.Closed)
                conn.Close();

            return result;
        }

        protected GridReader RunSPMultiple(IDbConnection conn, string spName, object parameters)
        {

            // conn = this.Connection;
            // var conn = this.Connection;
            // conn.Open ();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.AddDynamicParams(parameters);
            var result = conn.QueryMultiple(

                spName,
                dynamicParameters,
                null,
                null,
                commandType: CommandType.StoredProcedure
            );

            // if (conn.State != ConnectionState.Closed)
            //     conn.Close();

            return result;

        }

        protected dynamic RunExecuteSP<T>(IDbConnection conn, string spName, object parameters)
        {

            // conn = this.Connection;
            // var conn = this.Connection;
            // conn.Open ();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.AddDynamicParams(parameters);
            var result = conn.Execute(

                spName,
                dynamicParameters,
                null,
                null,
                commandType: CommandType.StoredProcedure
            );

            if (conn.State != ConnectionState.Closed)
                conn.Close();

            return result;

        }

        protected async Task<DataSet> RunExecuteSP(IDbConnection conn, string spName, object parameters, params string[] tableNames)
        {

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.AddDynamicParams(parameters);

            var reader = await conn.ExecuteReaderAsync(
                    spName,
                dynamicParameters,
                null,
                null,
                commandType: CommandType.StoredProcedure
            );


            DataSet ds = new DataSet();
            ds.Load(reader, LoadOption.OverwriteChanges, tableNames);

            if (conn.State != ConnectionState.Closed)
                conn.Close();

            return ds;
        }

        protected async Task<DataTable> RunExecuteSPAsync(IDbConnection conn, string spName, object parameters)
        {
            DataSet ds = await RunExecuteSP(conn, spName, parameters, "");
            return ds.Tables[0];
        }


        protected Exception CauseException(string message)
        {
            throw new Exception(message);
        }



        #region Disposable

        void IDisposable.Dispose()
        {
            // throw new NotImplementedException();
        }

        #endregion

    }
}