using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Ejercicio1.Modelo
{
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Cedula { get; set; }

        public int Estado { get; set; }
        public Persona(string nombre, int edad , string cedula , int estado)
        {
            Nombre = nombre;
            Edad = edad;
            Cedula = cedula;
            Estado = estado;
        }

    }

}

