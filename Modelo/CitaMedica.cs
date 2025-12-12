namespace API_Biblioteca.Modelo
{
    public class CitaMedica
    {
        public int Id { get; set; }
        public int Id_Paciente { get; set; }
        public int Id_Medico { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; } = "";
        public string Especialidad { get; set; } = "";
        public string Estado { get; set; } = "Pendiente"; // Confirmada / Cancelada / Pendiente
    }
}

