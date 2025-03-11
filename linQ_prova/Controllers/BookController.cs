using Microsoft.AspNetCore.Mvc;
using linQ_prova.Services;

namespace linQ_prova.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            this._bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var booksList = await _bookService.GetAllBooksAsync();

            return View(booksList);
        }
    }
}
