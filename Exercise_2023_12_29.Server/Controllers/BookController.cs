using Exercise_2023_12_29.Server.Models;
using Exercise_2023_12_29.Server.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exercise_2023_12_29.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet(Name = "GetBooksInfo")]
        public IEnumerable<Book> GetBookInfoBy([FromQuery] string searchBy, [FromQuery] string searchValue)
        {
            return _bookService.GetBooksInfoBy(searchBy, searchValue);
        }
    }
}
