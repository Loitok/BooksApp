using BooksApp.Data.Contexts;
using BooksApp.Data.Models;
using BooksApp.Data.Models.Result.Generics;
using BooksApp.Data.Models.Result.Implementations;
using BooksApp.Data.Models.Result.Interfaces;
using BooksApp.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult<IList<Book>>> GetAllBooksAsync()
        {
            try
            {
                var result = await _context.Books
                    .AsNoTracking()
                    .ToListAsync();

                return Result<List<Book>>.CreateSuccess(result);
            }
            catch (Exception e)
            {
                return Result<IList<Book>>.CreateFailure("Get Books Error", e);
            }
        }

        public async Task<IResult<IList<Book>>> GetSearchBooksAsync(string search)
        {
            try
            {
                var result = await _context.Books
                    .Where(x => x.Description.Contains(search)
                    || x.Title.Contains(search))
                    .AsNoTracking()
                    .ToListAsync();

                if (string.IsNullOrEmpty(search))
                {
                    var allBooks = await GetAllBooksAsync();

                    result = allBooks
                        .Data
                        .ToList();
                }
                return Result<List<Book>>.CreateSuccess(result);
            }
            catch (Exception e)
            {
                return Result<IList<Book>>.CreateFailure("Get Books Error", e);
            }
        }

        public async Task<IResult<Book>> GetBookAsync(int bookId)
        {
            try
            {
                var book = await _context.Books
                    .AsNoTracking()
                    .FirstAsync(x => x.Id == bookId);

                if (book is null)
                    return Result<Book>.CreateFailure("Book was not find");

                return Result<Book>.CreateSuccess(book);
            }
            catch (Exception e)
            {
                return Result<Book>.CreateFailure("Get Book Error", e);
            }
        }


        public async Task<IResult<int>> CreateBookAsync(Book model)
        {
            try
            {
                await _context.Books.AddAsync(model);

                return Result<int>.CreateSuccess(model.Id);
            }
            catch (Exception e)
            {
                return Result<int>.CreateFailure("Create Book Error", e);
            }
        }

        public async Task<IResult> UpdateBookAsync(int bookId, Book model)
        {
            try
            {
                var book = await _context.Books
                    .FirstOrDefaultAsync(x => x.Id == bookId);

                //_mapper.Map(employeeModel, employee);
                await _context.SaveChangesAsync();

                return Result.CreateSuccess();
            }
            catch (Exception e)
            {
                return Result.CreateFailure("Update Book Error", e);
            }
        }

        public async Task<IResult> DeleteBookAsync(IReadOnlyCollection<int> bookIds)
        {
            try
            {
                var books = await _context.Books
                    .Where(x => bookIds.Contains(x.Id))
                    .ToListAsync();


                _context.Books.RemoveRange(books);

                await _context.SaveChangesAsync();

                return Result.CreateSuccess();
            }
            catch (Exception e)
            {
                return Result.CreateFailure("Delete Books Error", e);
            }
        }
    }
}
