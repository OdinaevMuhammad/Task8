using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using infrastructure.Services;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController
    {
        private BookService _BookService;

        public BookController(BookService bookService)
        {
            _BookService = bookService;
        }


        [HttpGet("GetInfo")]
        public List<GetAuthor> GetBook()
        {
            return _BookService.GetBooks();
        }

        [HttpPost("Insert")]
        public int InsertBook(Book Book)
        {
            return _BookService.InsertBook(Book);
        }

        [HttpPut("Update")]
        public int UpdateBook(Book Book)
        {
            return _BookService.UpdateBook(Book);
        }
        [HttpDelete("Delete")]
        public int DeleteBook(int id)
        {
            return _BookService.DeleteBook(id);
        }
  
        
    }

}
