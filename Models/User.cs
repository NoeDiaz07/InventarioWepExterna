using System.ComponentModel.DataAnnotations;

namespace InventarioWepExterna.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }         // Identificador único
        public string Name { get; set; }   // Nombre del usuario
        public string Email { get; set; }  // Correo electrónico
        public string Career { get; set; } // Carrera
        public int Age { get; set; }       // Edad
        public string Enrollment { get; set; } // Matrícula
    }
}
