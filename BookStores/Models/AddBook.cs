using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStores.Models
{
    public class AddBook
    {
        public Store store { get; set; }
        public List<Book> books { get; set; }
        public Link link { get; set; }
    }
}