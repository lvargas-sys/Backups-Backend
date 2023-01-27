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



        public async Task<bool> createCustomers(Cliente dataCliente)
        {

            var query = @"INSERT INTO cliente(nombre_cliente) values (@nombre_cliente)";
            var parameters = new DynamicParameters();


            parameters.Add("nombre_cliente", dataCliente.nombre_cliente, DbType.String);

            using (var connection = _context.CreateConnection())
            {

                try
                {
                    var result = await connection.ExecuteAsync(query, parameters);
                    if (result <= 0)
                        return false;
                    else
                        return true;

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error `" + ex.Message);
                    return false;
                }


            }
        }


        public async Task<IEnumerable<Cliente>> getCustomerIdCliente(int id_cliente) {

            var query = "SELECT * FROM cliente where id_cliente = "+id_cliente;

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Cliente>(query);
                return companies.ToList();
            }


        }



    }
   

}
