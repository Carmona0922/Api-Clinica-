using API_Biblioteca.Modelo;

namespace API_Biblioteca.Data
{
    public class CitaRepository : JsonRepositoryBase<CitaMedica>
    {
        public CitaRepository()
            : base("Data/json/citas.json")
        { }

        public List<CitaMedica> GetAll()
        {
            return LoadAll();
        }

        public CitaMedica? GetById(int id)
        {
            return LoadAll().FirstOrDefault(c => c.Id == id);
        }

        public void Create(CitaMedica cita)
        {
            var citas = LoadAll();

            cita.Id = citas.Count == 0
                ? 1
                : citas.Max(c => c.Id) + 1;

            citas.Add(cita);
            SaveAll(citas);
        }

        public void UpdatePartial(int id, CitaMedica data)
        {
            var citas = LoadAll();
            var cita = citas.FirstOrDefault(c => c.Id == id);
            if (cita == null) return;

            if (data.Id_Paciente != 0) cita.Id_Paciente = data.Id_Paciente;
            if (data.Id_Medico != 0) cita.Id_Medico = data.Id_Medico;
            if (data.Fecha != default) cita.Fecha = data.Fecha;
            if (!string.IsNullOrEmpty(data.Hora)) cita.Hora = data.Hora;
            if (!string.IsNullOrEmpty(data.Especialidad)) cita.Especialidad = data.Especialidad;
            if (!string.IsNullOrEmpty(data.Estado)) cita.Estado = data.Estado;

            SaveAll(citas);
        }

        public void Delete(int id)
        {
            var citas = LoadAll();
            citas.RemoveAll(c => c.Id == id);
            SaveAll(citas);
        }
    }
}
