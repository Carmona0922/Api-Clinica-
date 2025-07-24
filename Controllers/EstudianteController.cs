
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using API_Ejercicio1.Data;
using API_Ejercicio1.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Ejercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {

        EstudianteQuery estQuery;

        public EstudianteController( )
        {
            estQuery = new EstudianteQuery();
        }


        // GET: api/<EstudianteController>
        [HttpGet]
        public List<Estudiante> Get()
        {
            List<Estudiante> estudiantes = estQuery.GetEstudiantes();
            return estudiantes;
        } 

       
        // GET api/<EstudianteController>/5
        
        [HttpGet("{id}")]
        public Estudiante Get(string id)
        {
            Estudiante estudiante = estQuery.BuscarEstudiante(id);
            return estudiante;
        }


        // POST api/<EstudianteController>
        [HttpPost]
        public void Post([FromBody] Estudiante estudiante)
        {
            estQuery.AgregarEstudiante(estudiante);
        }

        // PUT api/<EstudianteController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Estudiante estudiante)
        {
            estQuery.ActualizarEstudiante(id, estudiante);
        }

        // DELETE api/<EstudianteController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            estQuery.InactivarEstudiante2(id);
        }

     




    }
}
