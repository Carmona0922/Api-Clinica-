using API_Biblioteca.Autenticación;
using API_Biblioteca.Data;
using API_Biblioteca.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BasicAuthentication]
    public class CitasController : ControllerBase
    {
        private readonly CitaRepository repo = new();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var c = repo.GetById(id);
            if (c == null) return NotFound();
            return Ok(c);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CitaMedica c)
        {
            repo.Create(c);
            return Ok(c);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CitaMedica c)
        {
            repo.UpdatePartial(id, c);
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
