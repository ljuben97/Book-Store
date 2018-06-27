using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStores.Models;

namespace BookStores.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store

        private DatabaseEntities database;

        public StoreController()
        {
            database = new DatabaseEntities();
        }

        public ActionResult BuyBook(int storeId, int bookId)
        {
            System.Diagnostics.Debug.WriteLine(storeId + " " + bookId);
            BookBuy bookBuy = new BookBuy();
            bookBuy.bookExtended = new BookIndex();
            Link link = database.Links.FirstOrDefault(z => z.StoreID == storeId && z.BookID == bookId);
            bookBuy.bookExtended.book = database.Books.FirstOrDefault(z => z.Id == bookId);
            if (bookBuy.bookExtended.book.AuthorID != -1)
                bookBuy.bookExtended.author = database.Authors.FirstOrDefault(z => z.Id == bookBuy.bookExtended.book.AuthorID);
            bookBuy.store = database.Stores.FirstOrDefault(z => z.Id == storeId);
            bookBuy.Price = (int)link.Price;
            bookBuy.InStock = (int)link.InStock;
            bookBuy.Quantity = 0;
            return View(bookBuy);
        }

        [HttpPost]
        public ActionResult BuyBook(BookBuy bookBuy)
        {
            Link link = database.Links.FirstOrDefault(z => z.BookID == bookBuy.bookExtended.book.Id && z.StoreID == bookBuy.store.Id);
            link.InStock = link.InStock - bookBuy.Quantity;
            database.SaveChanges();
            return Redirect("/Store/Details/" + bookBuy.store.Id);
        }

        public ActionResult AddBook(int id)
        {
            AddBook addBook = new AddBook();
            addBook.store = database.Stores.FirstOrDefault(z => z.Id == id);
            addBook.books = database.Books.ToList();
            addBook.link = new Link();
            addBook.link.StoreID = id;
            return View(addBook);
        }

        [HttpPost]
        public ActionResult AddBook(AddBook addBook)
        {
            database.Links.Add(addBook.link);
            database.SaveChanges();
            return Redirect("/Store");
        }

        public ActionResult Details(int id)
        {
            StoreDetails storeDetails = new StoreDetails();
            storeDetails.store = database.Stores.FirstOrDefault(z => z.Id == id);
            storeDetails.books = new List<BookExtended>();
            foreach(Link link in database.Links.ToList())
                if(link.StoreID==id)
                {
                    Book book = database.Books.FirstOrDefault(z => z.Id == link.BookID);
                    BookExtended bookExtended = new BookExtended();
                    bookExtended.CreateObject(book, link);
                    storeDetails.books.Add(bookExtended);
                }
            return View(storeDetails);
        }

        public ActionResult Index()
        {
            List<StoreIndex> list = new List<StoreIndex>();
            foreach(Store store in database.Stores.ToList())
            {
                StoreIndex storeIndex = new StoreIndex(store);
                foreach (Link link in database.Links.ToList())
                    if (link.StoreID == store.Id)
                        storeIndex.BookCounter++;
                list.Add(storeIndex);
            }
            return View(list);
        }

        public ActionResult Add()
        {
            Store store = new Store();
            return View(store);
        }

        [HttpPost]
        public ActionResult Add(Store store)
        {
            database.Stores.Add(store);
            database.SaveChanges();
            return Redirect("/Store");
        }
    }
}