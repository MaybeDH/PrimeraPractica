using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("materia")]
    
    public class MateriaController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<MateriaController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public MateriaController(
            ILogger<MateriaController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear estudiantes
        [Route("")]
        [HttpPost]
        public IActionResult PostMateria(
            [FromBody] Materia materia)
        {
            _aplicacionContexto.Materia.Add(materia);
            _aplicacionContexto.SaveChanges();
            return Ok(materia);
        }
        //READ: Obtener lista de estudiantes
        [Route("")]
        [HttpGet]
        public IEnumerable<Materia> GetMateria()
        {
            return _aplicacionContexto.Materia.ToList();
        }
        //Update: Modificar estudiantes
        [Route("id")]
        [HttpPut]
        public IActionResult PutMateria([FromBody] Materia materia)
        {
            _aplicacionContexto.Materia.Update(materia);
            _aplicacionContexto.SaveChanges();
            return Ok(materia);
        }

        [Route("id")]
        [HttpDelete]
        public IActionResult DeleteMateria(int materiaID)
        {
            _aplicacionContexto.Materia.Remove(_aplicacionContexto.Materia.ToList().Where(x => x.id_materia == materiaID).FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(materiaID);
        }
    }
}