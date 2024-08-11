using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using Biblioteca.Data;
using System.Linq;

namespace Biblioteca.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Books/Details/5
        public IActionResult Details(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == id); // Corrigido para BookId
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // Outros métodos da classe
    }
}
