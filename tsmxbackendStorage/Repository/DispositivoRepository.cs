using Dapper;
using System.Data;
using tsmxbackendStorage.Context;
using tsmxbackendStorage.Contracts;
using tsmxbackendStorage.Entities;

namespace tsmxbackendStorage.Repository
{
    public class DispositivoRepository :IDispositivoRepository
    {

        private readonly DapperContext _context;


        public DispositivoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dispositivo>> getDevices()
        {
            var query = "SELECT * FROM dispositivo";

            using (var connection = _context.CreateConnection())
            {
                var dispositivo = await connection.QueryAsync<Dispositivo>(query);
                return dispositivo.ToList();
            }
        }



        public async Task<bool> createDevice(Dispositivo dataDispositivo)
        {
           
            var query = "INSERT INTO dispositivo (Nombre_dispositivo, contrato_soporte, Ip, End_life, End_support, Tipo, id_cliente) VALUES(@Nombre_dispositivo, @contrato_soporte, @Ip, @End_life, @End_support, @Tipo, @id_cliente)";
                 
           var parameters = new DynamicParameters();
      
           // parameters.Add("id_dispositvo", dataDispositivo.id_dispositvo, DbType.Int64);
            parameters.Add("Nombre_dispositivo", dataDispositivo.Nombre_dispositivo, DbType.String);
            parameters.Add("contrato_soporte", dataDispositivo.contrato_soporte, DbType.Date);
            parameters.Add("Ip", dataDispositivo.Ip, DbType.String);
            parameters.Add("End_life", dataDispositivo.End_life, DbType.Date);
            parameters.Add("End_support", dataDispositivo.End_support, DbType.Date);
            parameters.Add("Tipo", dataDispositivo.Tipo, DbType.String);
            parameters.Add("id_cliente", dataDispositivo.id_cliente, DbType.Int64);

            using (var connection = _context.CreateConnection())
            {
               
                var result = await connection.ExecuteAsync(query, parameters);
                if (result <= 0)
                    return false;
                else
                    return true;
                
            }
        }

        public async Task<IEnumerable<Dispositivo>> deleteDevices()
        {
            var query = "SELECT * FROM dispositivo";

            using (var connection = _context.CreateConnection())
            {
                var dispositivo = await connection.QueryAsync<Dispositivo>(query);
                return dispositivo.ToList();
            }
        }


    }


}
