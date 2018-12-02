using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new LibraryDB())
            {
                var allBooks = db.Books.ToList();
                return View(allBooks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid && book.Price<1)
            {
                return RedirectToAction("Index");
            }
            Book currentBook = new Book()
            {
                Title = book.Title,
                Author=book.Author,
                Price=book.Price
            };

            using (var db = new LibraryDB())
            {
                db.Books.Add(currentBook);
                db.SaveChanges();
            };

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new LibraryDB())
            {
                var oldBook = db.Books.FirstOrDefault(x => x.Id == id);
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                return this.View(oldBook);
            }
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            using (var db = new LibraryDB())
            {
                var oldBook = db.Books.FirstOrDefault(x => x.Id == book.Id);
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                oldBook.Title = book.Title;
                oldBook.Author = book.Author;
                oldBook.Price = book.Price;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new LibraryDB())
            {
                var currentBook = db.Books.FirstOrDefault(x => x.Id == id);
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                return View(currentBook);

            }
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            using (var db = new LibraryDB())
            {
                var currentBook = db.Books.FirstOrDefault(x => x.Id == book.Id);
                if (currentBook==null)
                {
                    return RedirectToAction("Index");
                }

                db.Books.Remove(currentBook);
                db.SaveChanges();


                return RedirectToAction("Index");

            }
        }
    }
}