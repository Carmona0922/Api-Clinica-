using API_Biblioteca.Modelo;

namespace API_Biblioteca.Data
{
    public class PacienteRepository : JsonRepositoryBase<Paciente>
    {
        public PacienteRepository()
            : base("Data/json/pacientes.json")
        { }

        public List<Paciente> GetAll()
        {
            return LoadAll();
        }

        public Paciente? GetById(int id)
        {
            return LoadAll().FirstOrDefault(p => p.Id == id);
        }

        public Paciente? GetByCedula(string cedula)
        {
            return LoadAll()
                .FirstOrDefault(p => p.Cedula == cedula);
        }

        public void Create(Paciente paciente)
        {
            var pacientes = LoadAll();

            paciente.Id = pacientes.Count == 0
                ? 1
                : pacientes.Max(p => p.Id) + 1;

            pacientes.Add(paciente);
            SaveAll(pacientes);
        }

        public void UpdatePartial(int id, Paciente data)
        {
            var pacientes = LoadAll();
            var paciente = pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente == null) return;

            // Actualiza SOLO lo que venga no nulo
            if (!string.IsNullOrEmpty(data.Nombre)) paciente.Nombre = data.Nombre;
            if (!string.IsNullOrEmpty(data.Cedula)) paciente.Cedula = data.Cedula;
            if (data.Fecha_Nacimiento != default) paciente.Fecha_Nacimiento = data.Fecha_Nacimiento;
            if (!string.IsNullOrEmpty(data.Genero)) paciente.Genero = data.Genero;
            if (!string.IsNullOrEmpty(data.Direccion)) paciente.Direccion = data.Direccion;
            if (!string.IsNullOrEmpty(data.Telefono)) paciente.Telefono = data.Telefono;
            if (!string.IsNullOrEmpty(data.Correo)) paciente.Correo = data.Correo;
            if (!string.IsNullOrEmpty(data.Estado_Clinico)) paciente.Estado_Clinico = data.Estado_Clinico;

            SaveAll(pacientes);
        }

        public void Delete(int id)
        {
            var pacientes = LoadAll();
            pacientes.RemoveAll(p => p.Id == id);
            SaveAll(pacientes);
        }
    }
}

