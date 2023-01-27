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
            var query = "SELECT * FROM dispositivo_almacenamiento";

            using (var connection = _context.CreateConnection())
            {
                var dispositivo = await connection.QueryAsync<Dispositivo>(query);
                return dispositivo.ToList();
            }
        }



        public async Task<bool> createDevice(Dispositivo dataDispositivo)
        {


            var queryDisp = @"INSERT INTO dispositivo_almacenamiento(Nombre_dispositivo, contrato_soporte, Ip, Tipo, id_cliente, performance, system_id, tenant_cmdb, assignament_group, category) values(@Nombre_dispositivo, @contrato_soporte, @Ip, @Tipo, @id_cliente, @performance, @system_id, @tenant_cmdb, @assignament_group, @category)";


            var parameters = new DynamicParameters();
            parameters.Add("Nombre_dispositivo", dataDispositivo.Nombre_dispositivo, DbType.String);
            parameters.Add("contrato_soporte", dataDispositivo.contrato_soporte, DbType.Date);
            parameters.Add("Ip", dataDispositivo.Ip, DbType.String);
            parameters.Add("Tipo", dataDispositivo.Tipo, DbType.String);
            parameters.Add("id_cliente", dataDispositivo.id_cliente, DbType.Int64);
            parameters.Add("performance", dataDispositivo.performance, DbType.Boolean);
            parameters.Add("system_id", dataDispositivo.system_id, DbType.String);
            parameters.Add("tenant_cmdb", dataDispositivo.tenant_cmdb, DbType.String);
            parameters.Add("assignament_group", dataDispositivo.assignament_group, DbType.String);
            parameters.Add("category", dataDispositivo.category, DbType.String);
           // Console.WriteLine(dataDispositivo.Nombre_dispositivo+" - "+dataDispositivo.contrato_soporte+" - "+dataDispositivo.Ip+" - "+dataDispositivo.Tipo+" - "+dataDispositivo.id_cliente+" - "+dataDispositivo.performance+" - "+dataDispositivo.system_id+" - "+dataDispositivo.tenant_cmdb+" - "+dataDispositivo.assignament_group+" - "+dataDispositivo.category);
            using (var connection = _context.CreateConnection())
            {

                try
                {
                    var result = await connection.ExecuteAsync(queryDisp, parameters);
                    if (result <= 0)
                        return false;
                    else
                        return true;

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error " + ex.Message);
                    return false;
                }


            }
        }



    }


}
