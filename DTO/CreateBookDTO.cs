namespace InventarioWepExterna.DTO
{
    /// <summary>
    /// DTO para crear un libro
    /// </summary>
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }
}
