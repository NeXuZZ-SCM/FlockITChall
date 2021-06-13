using FlockITChallenge.Entitie;
using FlockITChallenge.Service;
using FlockITChallenge.Utils;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FlockITChallenge.Repository
{
    public class AuthRepository
    {
        private readonly string _connStr = GetConnectionString();

        public static string GetConnectionString()
        {
            string conn = "";
            try
            {
                string environment = Startup.StaticConfig.GetValue<string>("Ambiente");
                conn = Startup.StaticConfig.GetValue<string>(("Ambientes:" + environment + ":ConnectionStrings"));
            }
            catch (Exception ex)
            {
                string exception = $"Manejar la excepcion segun corresponda {ex.Message}";
            }
            return conn;
        }
        public async Task<List<object>> getAuthJson(UserEntitie user, ILogService _logService)
        {
            List<object> list = new List<object>();
            string password = Crypto.MD5Hash(user.Password);
            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.CommandText = "FlockItChallenge.DBO.USER_C";
                        string jsonOutputParam = "@jsonOutput";


                        comm.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 20)).Value = user.User;
                        comm.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50)).Value = password;

                        comm.Parameters.Add(new SqlParameter(jsonOutputParam, SqlDbType.NVarChar, -1)).Direction = ParameterDirection.Output;
                        SqlDataReader reader = await comm.ExecuteReaderAsync();
                        string json = comm.Parameters[jsonOutputParam].Value.ToString();

                        ResponseUserEntitie userEntitie = new ResponseUserEntitie();
                        userEntitie = JsonConvert.DeserializeObject<ResponseUserEntitie>(json);
                        list.Add(userEntitie);
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                _logService.LogError(ex.Message);
                return null;
            }
        }
    }
}
