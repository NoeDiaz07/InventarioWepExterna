using System.ComponentModel.DataAnnotations;

namespace InventarioWepExterna.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }        
        public string Name { get; set; }   
        public string Email { get; set; }  
        public string Career { get; set; }
        public int Age { get; set; }       
        public string Enrollment { get; set; } 
    }
}
