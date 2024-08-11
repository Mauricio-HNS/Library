using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    public class RentedBooksController : Controller
    {
        private readonly ApplicationDbContext _db;

        // Construtor que recebe ApplicationDbContext via injeção de dependência.
        public RentedBooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Index(string search = null)
        {
            var model = _db.RentedBooks.ToList();
            List<RentedBooksAdminModelView> rentedBooks = new List<RentedBooksAdminModelView>();
            foreach (var item in model)
            {
                Book book = _db.Books.Find(item.BookId);
                RentedBooksAdminModelView rentedBook = new RentedBooksAdminModelView
                {
                    RentedBookId = item.RentedBookId,
                    BookId = item.BookId,
                    Title = book.Title,
                    UserName = item.UserName,
                    RentDate = item.RentDate,
                    ReturnDate = item.ReturnDate,
                    Penalty = item.Penalty
                };

                if (DateTime.Now > rentedBook.ReturnDate)
                    rentedBook.Penalty = rentedBook.Penalty + 1 * DateTime.Now.Second - rentedBook.ReturnDate.Second;

                rentedBooks.Add(rentedBook);
            }
            return View(rentedBooks);
        }

        public ActionResult RentConfirmation(int id)
        {
            Book book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            var model = new RentedBook
            {
                BookId = id,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(14),
                Penalty = 0
            };
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RentConfirmation(RentedBook rentedBook)
        {
            rentedBook.UserName = User.Identity.Name; // Alterado para `User.Identity.Name` que retorna o nome do usuário logado
            rentedBook.RentDate = DateTime.Now;
            rentedBook.ReturnDate = rentedBook.RentDate.AddDays(14);

            Book book = _db.Books.Find(rentedBook.BookId);
            if (book != null)
            {
                book.Available = false;
                _db.Entry(book).State = EntityState.Modified;
            }

            if (ModelState.IsValid)
            {
                _db.RentedBooks.Add(rentedBook);
                _db.SaveChanges();
                return RedirectToAction("Index", "Books");
            }

            return View(rentedBook);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            RentedBook rentedBook = _db.RentedBooks.Find(id);
            if (rentedBook == null)
            {
                return NotFound();
            }
            return View(rentedBook);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentedBook rentedBook = _db.RentedBooks.Find(id);
            if (rentedBook != null)
            {
                Book book = _db.Books.Find(rentedBook.BookId);
                if (book != null)
                {
                    book.Available = true;
                    _db.Entry(book).State = EntityState.Modified;
                }

                _db.RentedBooks.Remove(rentedBook);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
