using Dapper;
using System.Data;
using tsmxbackendStorage.Context;
using tsmxbackendStorage.Contracts;
using tsmxbackendStorage.Entities;

namespace tsmxbackendStorage.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly DapperContext _context;


        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> getCustomers()
        {
            var query = "SELECT * FROM cliente";

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Cliente>(query);
                return companies.ToList();
            }
        }



        public async Task<int> createCustomers(Cliente dataCliente)
        {
           
            var query = @"INSERT INTO cliente(nombre_cliente) values (@nombre_cliente)";
                 var parameters = new DynamicParameters();
            

            parameters.Add("nombre_cliente", dataCliente.nombre_cliente, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                // var cliente = await connection.ExecuteAsync(query,parameters);
                var id = connection.QuerySingle<int>(query, parameters);
               


                // return cliente.ToString();
                return id;
            }
        }


       
    }
   

}
