namespace tsmxbackendStorage.Entities
{
    public class Dispositivo
    {
        public int id_dispositivo { get; set; }
        public string Nombre_dispositivo { get; set; }
        public DateTime contrato_soporte { get; set; } //Date
        public string Ip { get; set; }
        public string Tipo { get; set; }
        public int id_cliente { get; set; } //llave foranea
        public bool performance { get; set; }
        public string system_id { get; set; }
        public string tenant_cmdb { get; set; }
        public string assignament_group { get; set; }
        public string category { get; set; }





    }
}
