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
        //
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            return View(db.Books);
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
            ViewBag.Person = purchase.Person;
            return "Спасибі," + purchase.Person + ", за покупку!";
        }
    }

}
