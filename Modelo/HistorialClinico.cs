namespace API_Biblioteca.Modelo
{
    public class HistorialClinico
    {
        public int Id { get; set; }
        public int Id_Paciente { get; set; }
        public int Id_Medico { get; set; }
        public string Diagnostico { get; set; } = "";
        public string Tratamiento { get; set; } = "";
        public DateTime Fecha_Consulta { get; set; }
    }
}
