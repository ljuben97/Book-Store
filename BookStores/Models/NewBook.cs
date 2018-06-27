using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStores.Models;

namespace BookStores.Models
{
    public class NewBook
    {
        public Book book { get; set; }
        public List<Author> authors;
    }
}