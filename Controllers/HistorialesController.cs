using API_Biblioteca.Autenticación;
using API_Biblioteca.Data;
using API_Biblioteca.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BasicAuthentication]
    public class HistorialesController : ControllerBase
    {
        private readonly HistorialRepository repo = new();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var h = repo.GetById(id);
            if (h == null) return NotFound();
            return Ok(h);
        }

        [HttpPost]
        public IActionResult Create([FromBody] HistorialClinico h)
        {
            repo.Create(h);
            return Ok(h);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] HistorialClinico h)
        {
            repo.UpdatePartial(id, h);
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
