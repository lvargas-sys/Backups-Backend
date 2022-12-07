namespace tsmxbackendStorage.Entities
{
    public class JobLog
    {
        public int Id { get; set; }
        public int id_cliente { get; set; }
        public int id_dispositvo { get; set; }
        public string backup_client_name { get; set; }
        public string job_id { get; set; }
        public string policy { get; set; }
        public string type { get; set; }
        public string schedule { get; set; }
        public DateTime start_datetime { get; set; }
        public string status { get; set; }
        public DateTime end_datetime { get; set; }
        public TimeSpan elapsed_time { get; set; } //time 
        public DateTime last_reading_at { get; set; } 
        public DateTime updated_at { get; set; } 

       


        

    }
}
