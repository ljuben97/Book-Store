using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStores.Models
{
    public class AuthorDetails
    {
        public Author author { get; set; }
        public List<Book> books { get; set; }
    }
}