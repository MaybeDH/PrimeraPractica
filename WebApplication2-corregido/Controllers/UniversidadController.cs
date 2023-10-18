using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;
namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("universidad")]
    public class UniversidadController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<UniversidadController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public UniversidadController(
            ILogger<UniversidadController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear estudiantes
        [Route("")]
        [HttpPost]
        public IActionResult PostUniversidad(
            [FromBody] Universidad universidad)

        {
            _aplicacionContexto.Universidad.Add(universidad);
            _aplicacionContexto.SaveChanges();
            return Ok(universidad);
        }
        //READ: Obtener lista de estudiante
        [Route("")]
        [HttpGet]
        public IEnumerable<Universidad> GetUniversidad()
        {
            return _aplicacionContexto.Universidad.ToList();
        }
        //Update: Modificar estudiantes
        [Route("/id")]
        [HttpPut]
        public IActionResult PutUniversidad([FromBody] Universidad universidad)
        {
            _aplicacionContexto.Universidad.Update(universidad);
            _aplicacionContexto.SaveChanges();
            return Ok(universidad);
        }
        //Delete: Eliminar estudiantes
        [Route("/id")]
        [HttpDelete]//(Name = "GetEstudiante")
        public IActionResult DeleteUniversidad(int universidadID)
        {
            _aplicacionContexto.Universidad.Remove(_aplicacionContexto.Universidad.ToList().Where(x => x.id_universidad == universidadID).FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(universidadID);
        }
    }
}
