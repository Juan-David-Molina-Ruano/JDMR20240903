using JDMR20240903.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JDMR20240903.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        static List<Aula> aulas = new List<Aula>();

        // obtener todas las aulas
        [HttpGet]
        public IEnumerable<Aula> Get()
        {
            return aulas;
        }

        //obtener un aula por id
        [HttpGet("{id}")]
        public Aula? Get(int id)
        {
            var aula = aulas.FirstOrDefault(x => x.Id == id);
            return aula;
        }

        //crear un aula
        [HttpPost]
        public IActionResult Post([FromBody] Aula aula)
        {
            aulas.Add(aula);
            return Ok();
        }

        //actualizar un aula por id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Aula aula)
        {
            var aulaToUpdate = aulas.FirstOrDefault(x => x.Id == id);

            if (aulaToUpdate == null)
            {
                return NotFound();
            }
         
            aulaToUpdate.Nombre = aula.Nombre;
            aulaToUpdate.Descripcion = aula.Descripcion;

            return Ok();
        }

        //eliiinar un aula por id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aulaToDelete = aulas.FirstOrDefault(x => x.Id == id);

            if (aulaToDelete == null)
            {
                return NotFound();
            }

            aulas.Remove(aulaToDelete);
            return Ok();
        }
    }
}
