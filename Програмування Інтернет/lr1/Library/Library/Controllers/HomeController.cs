using Library.Models;
using System;
using System.Collections.Generic;
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
        }
}
