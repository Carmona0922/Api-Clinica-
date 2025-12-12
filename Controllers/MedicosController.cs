using API_Biblioteca.Autenticación;
using API_Biblioteca.Data;
using API_Biblioteca.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BasicAuthentication]
    public class MedicosController : ControllerBase
    {
        private readonly MedicoRepository repo = new();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var m = repo.GetById(id);
            if (m == null) return NotFound();
            return Ok(m);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Medico m)
        {
            repo.Create(m);
            return Ok(m);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Medico m)
        {
            repo.UpdatePartial(id, m);
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
