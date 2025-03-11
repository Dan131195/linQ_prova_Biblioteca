using linQ_prova.Data;
using linQ_prova.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace linQ_prova.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext _context;

        // Qui collego il database all'appilicazione e al DbContext
        public BookService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<BooksListViewModel> GetAllBooksAsync()
        {
            var booksList = new BooksListViewModel();
            booksList.Books = await _context.Books.ToListAsync();

            return booksList;
        }
    }
}
