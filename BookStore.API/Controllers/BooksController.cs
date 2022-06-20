using BookStore.API.Models;
using BookStore.API.Repository;
using BookStore.API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _booksRepository;

        public BooksController(IBookRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GettAllBooks()
        {
            var books = await _booksRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBookById([FromRoute] int bookId)
        {
            var book = await _booksRepository.GetBookById(bookId);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] BooksModel bookModel)
        {
            var id = await _booksRepository.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(GetBookById), new { id = bookModel.Id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BooksModel bookModel,[FromRoute] int id)
        {
             await _booksRepository.UpdateBookAsync(id, bookModel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument bookModel, [FromRoute] int id)
        {
            await _booksRepository.UpdateBooPatchkAsync(id, bookModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _booksRepository.DeleteBookAsync(id);
            return Ok();
        }
    }
}
