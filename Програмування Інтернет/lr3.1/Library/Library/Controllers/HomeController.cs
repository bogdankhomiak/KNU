using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
        {
            // GET: /Home/
            BookContext db = new BookContext();
            public ActionResult Index()
            {
            // Отримуємо з БД всі об'єкти Book
                IEnumerable<Book> books = db.Books;
            // Передаємо всі  об'єкти в динамічну властивість Books в ViewBag
                ViewBag.Books = books;
            // Повертаємо представлення
                return View();
            }
            [HttpGet]
            public ActionResult Buy(int id)
            {
                ViewBag.BookId = id;
                return View();
            }
            [HttpPost]
            public string Buy(Purchase purchase)
            {
                purchase.Date = DateTime.Now;
                // Додаємо інформацію про покупку в базу даних
                db.Purchases.Add(purchase);
                //  Зберігаємо в БД всі зміни
                db.SaveChanges();
                return "Спасибі," + purchase.Person + ", за покупку!";
            }
            public ActionResult BookView(int id)
            {
                var book = db.Books.Find(id);
                if (book != null)
                {
                    return View(book);
                }
                return RedirectToAction("Index");
            } 
        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.Entry(book).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Book b = new Book { Id = id };
            db.Entry(b).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        }
}
