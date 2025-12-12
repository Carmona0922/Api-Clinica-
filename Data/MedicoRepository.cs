using API_Biblioteca.Modelo;

namespace API_Biblioteca.Data
{
    public class MedicoRepository : JsonRepositoryBase<Medico>
    {
        public MedicoRepository()
            : base("Data/json/medicos.json")
        { }

        public List<Medico> GetAll()
        {
            return LoadAll();
        }

        public Medico? GetById(int id)
        {
            return LoadAll().FirstOrDefault(m => m.Id == id);
        }

        public void Create(Medico medico)
        {
            var medicos = LoadAll();

            medico.Id = medicos.Count == 0
                ? 1
                : medicos.Max(m => m.Id) + 1;

            medicos.Add(medico);
            SaveAll(medicos);
        }

        public void UpdatePartial(int id, Medico data)
        {
            var medicos = LoadAll();
            var medico = medicos.FirstOrDefault(m => m.Id == id);
            if (medico == null) return;

            if (!string.IsNullOrEmpty(data.Nombre)) medico.Nombre = data.Nombre;
            if (!string.IsNullOrEmpty(data.Cedula_Profesional)) medico.Cedula_Profesional = data.Cedula_Profesional;
            if (!string.IsNullOrEmpty(data.Especialidad)) medico.Especialidad = data.Especialidad;
            if (!string.IsNullOrEmpty(data.Telefono)) medico.Telefono = data.Telefono;
            if (!string.IsNullOrEmpty(data.Correo)) medico.Correo = data.Correo;
            if (!string.IsNullOrEmpty(data.Horario_Consulta)) medico.Horario_Consulta = data.Horario_Consulta;
            if (!string.IsNullOrEmpty(data.Estado)) medico.Estado = data.Estado;

            SaveAll(medicos);
        }

        public void Delete(int id)
        {
            var medicos = LoadAll();
            medicos.RemoveAll(m => m.Id == id);
            SaveAll(medicos);
        }
    }
}
