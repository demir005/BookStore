using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Repository.IRepository
{
    public interface IBookRepository
    {
        Task<List<BooksModel>> GetAllBooksAsync();

        Task<BooksModel> GetBookById(int bookId);

        Task<int> AddBookAsync(BooksModel bookModel);

        Task UpdateBookAsync(int bookId, BooksModel bookModel);

        Task UpdateBooPatchkAsync(int bookId, JsonPatchDocument bookModel);

        Task DeleteBookAsync(int bookId);
    }
}
