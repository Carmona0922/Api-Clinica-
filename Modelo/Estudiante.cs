using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Ejercicio1.Modelo
{
    public class Estudiante : Persona
    {
        public string Carrera { get; set; }
        public string NumeroMatricula { get; set; }


        public Estudiante(string nombre, int edad,string cedula,int estado,string carrera, string numeroMatricula)
            : base(nombre, edad, cedula, estado)
        {
            Carrera = carrera;
            NumeroMatricula = numeroMatricula;
        }

    }
}
