
using API_Ejercicio1.Modelo;
using System.Text.Json;

namespace API_Ejercicio1.Data
{
    public class EstudianteQuery
    {


        private List<Estudiante> estudiantes;
        private const string RutaBase = @"C:\Users\David Universidad\Downloads\API_Biblioteca\Archivos\";
        private const string ArchivoEstudiantes = RutaBase + "estudiantes.json";
        


        public EstudianteQuery()
        {
            estudiantes = new List<Estudiante>();
            VerificarCarpeta(); // Asegura que la carpeta exista antes de cargar datos
            CargarDatos();
        }

        private void VerificarCarpeta()
        {
            if (!Directory.Exists(RutaBase))
            {
                Directory.CreateDirectory(RutaBase);
            }
        }
        public List<Estudiante> GetEstudiantes()
        {
            return estudiantes;
        }

 


        public void AgregarEstudiante(Estudiante estudiante)
        {
            string nombre = estudiante.Nombre;
            int edad = estudiante.Edad;
            string cedula = estudiante.Cedula;
            string carrera = estudiante.Carrera;
            string matricula = estudiante.NumeroMatricula;
            int estado = estudiante.Estado;

            Estudiante nuevoEstudiante = new Estudiante(nombre, edad, cedula, estado, carrera, matricula);
            estudiantes.Add(nuevoEstudiante);
            GuardarEstudiantes(); 

        }

        public Estudiante BuscarEstudiante(string cedula)
        {
            foreach(var estudiante in estudiantes)
            {
                if(estudiante.Cedula == cedula)
                {
                    return estudiante;
                }
            }
            return null;
        }

        public void ActualizarEstudiante(string cedula, Estudiante estudiante)
        {
            foreach (var est in estudiantes)
            {
                if (est.Cedula == cedula)
                {
                    est.Nombre = estudiante.Nombre;
                    est.Carrera = estudiante.Carrera;
                    est.Edad = estudiante.Edad;
                    est.NumeroMatricula = estudiante.NumeroMatricula;
                    est.Estado = 1;
                    GuardarEstudiantes();
                    break;
                }
            }
        }

        public void InactivarEstudiante(string cedula)
        {
            foreach (var est in estudiantes)
            {
                if (est.Cedula == cedula)
                {
                    est.Estado = 0;
                    GuardarEstudiantes();
                    break;
                }
            }
        }

   

        private void GuardarEstudiantes()
        {
            string jsonString = JsonSerializer.Serialize(estudiantes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ArchivoEstudiantes, jsonString);
        }

        private void CargarDatos()
        {

            string jsonString;

            if (File.Exists(ArchivoEstudiantes))
            {
                foreach (var linea in File.ReadAllLines(ArchivoEstudiantes))
                {
                    jsonString = File.ReadAllText(ArchivoEstudiantes);
                    estudiantes = JsonSerializer.Deserialize<List<Estudiante>>(jsonString);
                }
            }

        }






    }
}
