using System.ComponentModel.DataAnnotations;

namespace InventarioWepExterna.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }         // Identificador único
        public string Title { get; set; }  // Título del libro
        public string Author { get; set; } // Autor del libro
        public int Year { get; set; }      // Año de publicación
        public decimal Price { get; set; } // Precio del libro
        public bool IsAvailable { get; set; } // Estado (disponible o no)

    }
}
