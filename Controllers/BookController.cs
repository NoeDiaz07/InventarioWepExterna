using AutoMapper;
using InventarioWepExterna.DTO;
using InventarioWepExterna.Models;
using InventarioWepExterna.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

[ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
    private readonly ApplicationDbcontext _context;
    private readonly IMapper _mapper;
    public BooksController(ApplicationDbcontext context,IMapper mapper)
    {
            _context = context;
        _mapper = mapper;
        }

        [HttpGet("GetAllBooks")]
        
        public async Task <ActionResult<IEnumerable<Book>>>GetAllBooks() 
         {
        var books = await _context.Books
             .Select(p => new
             {
                 p.Id,
                 p.Author,
                 p.Year,
                 p.Price,
                 p.IsAvailable
             }).ToListAsync();
        return Ok(books);
         }

        [HttpGet("GetBookById/{id}")]
    public async Task<ActionResult<Book>> GetBookById(int id)
        {
      var book = await _context.Books.FindAsync(id);
        if (book==null) return NotFound();
         return Ok(book);
        }
    
    [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook(CreateBookDTO newBook)
        {
        var BookAutoMapp = _mapper.Map<Book>(newBook);
        _context.Books.Add(BookAutoMapp);
            await _context.SaveChangesAsync();
        return Ok(newBook);
        }
    
    [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
        //    var book = Books.FirstOrDefault(b => b.Id == id);
         //   if (book == null) return NotFound();

        //    book.Title = updatedBook.Title;
        //    book.Author = updatedBook.Author;
        //    book.Year = updatedBook.Year;
        //    book.Price = updatedBook.Price;
       //     book.IsAvailable = updatedBook.IsAvailable;

            return NoContent();
        }

        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(int id)
        {
        //var book = .FirstOrDefault(b => b.Id == id);
        //    if (book == null) return NotFound()
        //    .Remove(book);
            return NoContent();
        }
    }

