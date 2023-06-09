﻿using Dapper;
using System.Data;
using tsmxbackendStorage.Context;
using tsmxbackendStorage.Contracts;
using tsmxbackendStorage.Entities;

namespace tsmxbackendStorage.Repository
{
    public class JobRepository : IJobRepository
    {

        private readonly DapperContext _context;


        public JobRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobLog>> getJob()
        {
            var query = "SELECT * FROM  log_job";

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var job = await connection.QueryAsync<JobLog>(query);
                    return job.ToList();
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
               
            }
        }


        public async Task<IEnumerable<JobLog>> getJobStatus(string status)
        {
            var query = "SELECT * FROM  log_job  where status = '"+status+"'";

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var job = await connection.QueryAsync<JobLog>(query);
                    return job.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }

            }

        }


        public async Task<bool> createJob(JobLog dataJob)
        {

            var query = "INSERT INTO log_job (id_cliente, id_dispositvo, backup_client_name, job_id, policy, type, schedule, start_datetime, status, end_datetime, elapsed_time, last_reading_at, updated_at) VALUES(@id_cliente,@id_dispositvo, @backup_client_name, @job_id, @policy, @type, @schedule, @start_datetime, @status, @end_datetime, @elapsed_time, @last_reading_at, @updated_at)";


            var parameters = new DynamicParameters();

            parameters.Add("id_cliente", dataJob.id_cliente, DbType.Int64);
            parameters.Add("id_dispositvo", dataJob.id_dispositvo, DbType.Int64);
            parameters.Add("backup_client_name", dataJob.backup_client_name, DbType.String);
            parameters.Add("job_id", dataJob.job_id, DbType.String);
            parameters.Add("policy", dataJob.policy, DbType.String);
            parameters.Add("type", dataJob.type, DbType.String);
            parameters.Add("schedule", dataJob.schedule, DbType.String);
            parameters.Add("start_datetime", dataJob.start_datetime, DbType.DateTime);
            parameters.Add("status", dataJob.status, DbType.String);
            parameters.Add("end_datetime", dataJob.end_datetime, DbType.DateTime);
            parameters.Add("elapsed_time", dataJob.elapsed_time, DbType.Time);
            parameters.Add("last_reading_at", dataJob.last_reading_at, DbType.DateTime);
            parameters.Add("updated_at", dataJob.updated_at, DbType.DateTime);

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
                catch (Exception ex) {

                    Console.WriteLine("Error `"+ex.Message);
                    return false;
                }

              

            }
        }




    }


}
