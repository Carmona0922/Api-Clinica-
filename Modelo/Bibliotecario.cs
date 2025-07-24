using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Ejercicio1.Modelo
{
    public class Bibliotecario: Persona
    {
        public string IDEmpleado { get; set; }
        public int AñosExperiencia { get; set; }

        public Bibliotecario(string nombre, int edad,string cedula, int estado, string idEmpleado, int añosExperiencia)
            : base(nombre, edad , cedula , estado)
        {
            IDEmpleado = idEmpleado;
            AñosExperiencia = añosExperiencia;
        }

    }
}
