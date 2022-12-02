using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using infrastructure.Services;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController
    {
        private AuthorService _AuthorService;

        public AuthorController(AuthorService authorService)
        {
            _AuthorService = authorService;
        }


        [HttpGet("GetInfo")]
        public   Task<List<GetAuthor>> GetAuthor()
        {
            return _AuthorService.GetAuthors();
        }

        [HttpPost("Insert")]
        public int InsertAuthor(Author Author)
        {
            return _AuthorService.InsertAuthor(Author);
        }

        [HttpPut("Update")]
        public int UpdateAuthor(Author Author)
        {
            return _AuthorService.UpdateAuthor(Author);
        }
          [HttpDelete("Delete")]
        public int DeleteAuthor(int id)
        {
            return _AuthorService.DeleteAuthor(id);
        }
  
        
    }

}
