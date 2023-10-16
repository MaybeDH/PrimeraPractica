using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    
    public class Estudiantes
    {
        [Key]
        public int id_estudiante { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string sexo { get; set; }
        public int id_universidad { get; set; }
    }
    public class Universidad
    {
        [Key]
        public int id_universidad { get; set; }
        public string nombre { get; set; }
    }
    public class Docente
    {
        [Key]
        public int id_docente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string ubicacion { get; set; }
        public bool sexo { get; set; }
        public int ci { get; set; }
        public int id_universidad { get; set; }
    }
}