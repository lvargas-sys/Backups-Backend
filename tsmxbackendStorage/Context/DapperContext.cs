using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace tsmxbackendStorage.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection()
            => new MySqlConnection(_connectionString);
       

          /*public DapperContext(): base(GetRDSConnectionString())
          {

          }
          public static DapperContext Create()
          {
              return new DapperContext();
          }*/
    }
}
