namespace tsmxbackendStorage.Entities
{
    public class Dispositivo
    {
        public int id_dispositvo { get; set; }
        public string Nombre_dispositivo { get; set; }
        public DateTime contrato_soporte { get; set; } //Date
        public string Ip { get; set; }
        public DateTime End_life { get; set; } //Date
        public DateTime End_support { get; set; } //Date
        public string Tipo { get; set; }
        public int id_cliente { get; set; } //llave foranea

    }
}
