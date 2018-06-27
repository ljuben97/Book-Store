using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStores.Models;

namespace Project.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        private DatabaseEntities database;

        public AuthorController()
        {
            database = new DatabaseEntities();
        }

        public ActionResult Index()
        {
            List<ListAuthor> list = new List<ListAuthor>();
            foreach (Author author in database.Authors.ToList())
            {
                ListAuthor x = new ListAuthor(author);
                foreach (Book book in database.Books.ToList())
                    if (book.AuthorID == author.Id)
                        x.BookCounter++;
                list.Add(x);
            }
            return View(list);
        }

        public ActionResult Add()
        {
            NewAuthor newAuthor = new NewAuthor();
            newAuthor.author = new Author();
            return View(newAuthor);
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                AuthorDetails authorDetails = new AuthorDetails();
                authorDetails.author = database.Authors.FirstOrDefault(z => z.Id == id);
                authorDetails.books = new List<Book>();
                foreach (Book book in database.Books.ToList())
                    if (book.AuthorID == id)
                        authorDetails.books.Add(book);
                return View(authorDetails);
            }
            else return Redirect("/Author");
        }

        [HttpPost]
        public ActionResult Add(NewAuthor newauthor)
        {
            DateTime born = new DateTime(Int32.Parse(newauthor.birthYear), Int32.Parse(newauthor.birthMonth), Int32.Parse(newauthor.birthDate));
            newauthor.author.Born = born;
            if ((bool)newauthor.author.isDead)
            {
                DateTime died = new DateTime(Int32.Parse(newauthor.deathYear), Int32.Parse(newauthor.deathMonth), Int32.Parse(newauthor.deathDate));
                newauthor.author.Died = died;
            }
            database.Authors.Add(newauthor.author);
            database.SaveChanges();
            return Redirect("/Author");
        }
    }
}