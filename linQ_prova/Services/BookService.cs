using linQ_prova.Data;
using linQ_prova.Models;
using linQ_prova.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        // Metodo per salvare le modifiche nel Datbase tramite il DBContext
        private async Task<bool> MySaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<BooksListViewModel> GetAllBooksAsync()
        {
            var booksList = new BooksListViewModel();
            try
            {
                booksList.Books = await _context.Books.ToListAsync();
            }
            catch
            {
                booksList.Books = null;
            }

            return booksList;
        }

        public async Task<bool> AddBookAsync(AddBookViewModel addBookViewModel)
        {
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Titolo = addBookViewModel.Titolo,
                Autore = addBookViewModel.Autore,
                Genere = addBookViewModel.Genere
            };

            _context.Books.Add(book);

            return await MySaveAsync();
            
        }

        public async Task<Book?> GetBookByIdAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            if(book == null)
            {
                return null;
            }

            return book;
        }

        public async Task<bool> DeleteBookByIdAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null) 
            {
                return false;
            }

            _context.Books.Remove(book);
            return await MySaveAsync();
        }

        public async Task<bool> EditBookByIdAsync(EditBookViewModel editBookViewModel)
        {
            var book = await _context.Books.FindAsync(editBookViewModel.Id);

            if (book == null)
            {
                return false;
            }

            book.Titolo = editBookViewModel.Titolo;
            book.Autore = editBookViewModel.Autore;
            book.Genere = editBookViewModel.Genere;

            return await MySaveAsync();
        }
    }
}
