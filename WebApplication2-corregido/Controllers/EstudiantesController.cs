using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[ApiController]
    //[Route("api/[controller]")]
    //[SwaggerTag("Operaciones de estudiantes")]
    //[Produces("application/json")]
    public class EstudiantesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<EstudiantesController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public EstudiantesController(
            ILogger<EstudiantesController> logger, 
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear estudiantes
        [Route("")]
        [HttpPost]
        public IActionResult PostEstudiante(
            [FromBody] Estudiantes estudiante)
        {
            _aplicacionContexto.Estudiantes.Add(estudiante);
            _aplicacionContexto.SaveChanges();
            return Ok(estudiante);
        }
        //READ: Obtener lista de estudiantes
        [Route("")]
        [HttpGet]
        public IEnumerable<Estudiantes> GetEstudiante()
        {
            return _aplicacionContexto.Estudiantes.ToList();
        }
        //Update: Modificar estudiantes
        [Route("id")]
        [HttpPut]
        public IActionResult PutEstudiante([FromBody] Estudiantes estudiante)
        {
            _aplicacionContexto.Estudiantes.Update(estudiante);
            _aplicacionContexto.SaveChanges();
            return Ok(estudiante);
        }
        //Delete: Eliminar estudiantes
        /*[Route("/id")]
       [HttpDelete]//(Name = "GetEstudiante")
       public IActionResult DeleteEstudiante(int estudianteID)
       {
           _aplicacionContexto.Estudiantes.Remove(_aplicacionContexto.Estudiantes.ToList().Where(x => x.id_estudiante == estudianteID).FirstOrDefault());
           _aplicacionContexto.SaveChanges();
           return Ok(estudianteID);
       }*/

        [Route("id")]
        [HttpDelete]//(Name = "GetEstudiante")
        public IActionResult DeleteEstudiante(int estudianteID)
        {
            _aplicacionContexto.Estudiantes.Remove(_aplicacionContexto.Estudiantes.ToList().Where(x => x.id_estudiante == estudianteID).FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(estudianteID);
        }
    }
}