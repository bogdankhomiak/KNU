using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book
    {
        // ID книги
        public int Id { get; set; }
        // назва книги
        public string Name { get; set; }
        // автор книги
        public string Author { get; set; }
        // ціна
        public int Price { get; set; }
    }
    public class Purchase
    {
        // ID покупки
        public int PurchaseId { get; set; }
        // ім’я і прізвище покупця
        public string Person { get; set; }
        // адреса покупця
        public string Address { get; set; }
        // ID книги
        public int BookId { get; set; }
        // дата покупки
        public DateTime Date { get; set; }
    }

}