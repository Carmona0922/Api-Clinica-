using API_Biblioteca.Modelo;

namespace API_Biblioteca.Data
{
    public class HistorialRepository : JsonRepositoryBase<HistorialClinico>
    {
        public HistorialRepository()
            : base("Data/json/historiales.json")
        { }

        public List<HistorialClinico> GetAll()
        {
            return LoadAll();
        }

        public HistorialClinico? GetById(int id)
        {
            return LoadAll().FirstOrDefault(h => h.Id == id);
        }

        public void Create(HistorialClinico historial)
        {
            var historiales = LoadAll();

            historial.Id = historiales.Count == 0
                ? 1
                : historiales.Max(h => h.Id) + 1;

            historiales.Add(historial);
            SaveAll(historiales);
        }

        public void UpdatePartial(int id, HistorialClinico data)
        {
            var historiales = LoadAll();
            var historial = historiales.FirstOrDefault(h => h.Id == id);
            if (historial == null) return;

            if (data.Id_Paciente != 0) historial.Id_Paciente = data.Id_Paciente;
            if (data.Id_Medico != 0) historial.Id_Medico = data.Id_Medico;
            if (!string.IsNullOrEmpty(data.Diagnostico)) historial.Diagnostico = data.Diagnostico;
            if (!string.IsNullOrEmpty(data.Tratamiento)) historial.Tratamiento = data.Tratamiento;
            if (data.Fecha_Consulta != default) historial.Fecha_Consulta = data.Fecha_Consulta;

            SaveAll(historiales);
        }

        public void Delete(int id)
        {
            var historiales = LoadAll();
            historiales.RemoveAll(h => h.Id == id);
            SaveAll(historiales);
        }
    }
}
