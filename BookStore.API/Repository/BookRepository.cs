using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;
using BookStore.API.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContex _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContex context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BooksModel>> GetAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return _mapper.Map<List<BooksModel>>(books);
        }

        public async Task<BooksModel> GetBookById(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BooksModel>(book);
        }

        public async Task<int> AddBookAsync(BooksModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return bookModel.Id;
        }

        public async Task UpdateBookAsync(int bookId, BooksModel bookModel)
        {
            var book = new Books()
            {
                Id = bookId,
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBooPatchkAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = new Books() { Id = bookId };
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
