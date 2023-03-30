using BooksApp.Data.Models;
using BooksApp.Data.Models.Result.Generics;
using BooksApp.Data.Models.Result.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksApp.Services.Abstractions
{
    public interface IBookService
    {
        Task<IResult<IList<Book>>> GetAllBooksAsync();
        Task<IResult<IList<Book>>> GetSearchBooksAsync(string search);
        Task<IResult<Book>> GetBookAsync(int bookId);

        Task<IResult<int>> CreateBookAsync(Book model);
        Task<IResult> UpdateBookAsync(int bookId, Book model);
        Task<IResult> DeleteBookAsync(IReadOnlyCollection<int> bookIds);

    }
}
