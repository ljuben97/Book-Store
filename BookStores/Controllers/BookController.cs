using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStores.Models;

namespace Project.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private DatabaseEntities database;

        public BookController()
        {
            database = new DatabaseEntities();
        }

        public ActionResult Details(int id)
        {
            BookDetails bookDetails = new BookDetails();
            bookDetails.book = database.Books.FirstOrDefault(z => z.Id == id);
            if (bookDetails.book.AuthorID != -1) bookDetails.author = database.Authors.FirstOrDefault(z => z.Id == bookDetails.book.AuthorID);
            bookDetails.storesExt = new List<StoreExtended>();
            foreach (Link link in database.Links.ToList())
                if (link.BookID == id)
                {
                    StoreExtended extended = new StoreExtended();
                    extended.store = database.Stores.FirstOrDefault(z => z.Id == link.StoreID);
                    extended.price = (int)link.Price;
                    bookDetails.storesExt.Add(extended);
                }
            return View(bookDetails);
        }

        public ActionResult Index()
        {
            List<BookIndex> booksIndex = new List<BookIndex>();
            foreach (Book book in database.Books.ToList())
            {
                BookIndex bookIndex = new BookIndex();
                bookIndex.book = book;
                if (book.AuthorID != -1) bookIndex.author = database.Authors.FirstOrDefault(z => z.Id == book.AuthorID);
                booksIndex.Add(bookIndex);
            }
            return View(booksIndex);
        }

        [HttpPost]
        public ActionResult Add(NewBook newbook)
        {
            database.Books.Add(newbook.book);
            database.SaveChanges();
            return Redirect("/Book");
        }

        public ActionResult Add()
        {
            NewBook newbook = new NewBook();
            newbook.book = new Book();
            newbook.authors = database.Authors.ToList();
            return View(newbook);
        }
    }
}