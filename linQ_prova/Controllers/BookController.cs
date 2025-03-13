using Microsoft.AspNetCore.Mvc;
using linQ_prova.Services;
using linQ_prova.ViewModel;

namespace linQ_prova.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            this._bookService = bookService;
        }

        // Recupera il libri dal Database
        public async Task<IActionResult> Index()
        {
            var booksList = await _bookService.GetAllBooksAsync();

            return View(booksList);
        }

        // Apre il form per inserire un Libro
        public IActionResult Add()
        {
            return View();
        }

        // Salva il libro da aggiungere nel dbContext e di conseguenza nel Database vero e proprio
        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel addBookViewModel) 
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore durante il salvataggio nel database.";
                return RedirectToAction("Index");
            }

            var result = await _bookService.AddBookAsync(addBookViewModel);

            if(!result)
            {
                TempData["Error"] = "Errore durante il salvataggio nel database.";
                
            }
            return RedirectToAction("Index");
        }

        [Route("libro/dettaglio/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if(book == null)
            {
                TempData["Error"] = "Errore nel caricamento del dettaglio di un libro.";
                return RedirectToAction("Index");
            }

            var bookDetailsViewModel = new BookDetailsViewModel()
            {
                Id = book.Id,
                Titolo = book.Titolo,
                Autore = book.Autore,
                Genere = book.Genere
            };

            return View(bookDetailsViewModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bookService.DeleteBookByIdAsync(id);

            if(!result)
            {
                TempData["Error"] = "Errore durante l'eleminazione del libro.";
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("Index");
            };

            var editBookViewModel = new EditBookViewModel()
            {
                Id = book.Id,
                Titolo = book.Titolo,
                Autore = book.Autore,
                Genere = book.Genere
            };

            return View(editBookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBookViewModel editBookViewModel)
        {
            var result = await _bookService.EditBookByIdAsync(editBookViewModel);

            if (!result)
            {
                TempData["Error"] = "Errore nella modifica del libro.";
            }
            return  RedirectToAction("Index");
        }

    }
}
