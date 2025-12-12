using API_Biblioteca.Autenticación;
using API_Biblioteca.Data;
using API_Biblioteca.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BasicAuthentication] // Activa usuario y contraseña
    public class PacientesController : ControllerBase
    {
        private readonly PacienteRepository repo = new();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var p = repo.GetById(id);
            if (p == null) return NotFound();
            return Ok(p);
        }

        [HttpGet("cedula/{cedula}")]
        public IActionResult GetByCedula(string cedula)
        {
            var p = repo.GetByCedula(cedula);
            if (p == null) return NotFound();
            return Ok(p);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Paciente p)
        {
            repo.Create(p);
            return Ok(p);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Paciente p)
        {
            repo.UpdatePartial(id, p);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return Ok();
        }
    }
}
