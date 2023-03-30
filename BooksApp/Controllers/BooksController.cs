using BooksApp.Data.Models;
using BooksApp.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
            => _service = service;
        

        public async Task<ActionResult<IEnumerable<Book>>> BooksList()
        {
            var result = await _service.GetAllBooksAsync();
            if (!result.Success)
                ViewBag.error = result.ErrorMessage.Message;

            return View(result.Data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> SearchBooks(string searchString)
        {
            var result = await _service.GetSearchBooksAsync(searchString);
            if (!result.Success)
                ViewBag.error = result.ErrorMessage.Message;

            return Json(result.Data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var result = await _service.GetAllBooksAsync();
            if (!result.Success)
                ViewBag.error = result.ErrorMessage.Message;

            return Json(result.Data);
        }

        [HttpGet]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var result = await _service.GetBookAsync(id);
            if (!result.Success)
                ViewBag.error = result.ErrorMessage.Message;

            return Json(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book model)
        {
            var result = await _service.CreateBookAsync(model);
            if (!result.Success)
                ViewBag.error = result.ErrorMessage.Message;

            return Json(result.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(int id, Book model)
        {
            var result = await _service.UpdateBookAsync(id, model);
            if (!result.Success)
                ViewBag.error = result.ErrorMessage.Message;

            return Json("Update Employee Success!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooks(IReadOnlyCollection<int> bookIds)
        {
            var result = await _service.DeleteBookAsync(bookIds);
            if (!result.Success)
                ViewBag.error = result.ErrorMessage.Message;

            return Json("Delete Books Success!");
        }
    }
}
