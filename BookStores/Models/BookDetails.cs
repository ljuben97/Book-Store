using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStores.Models
{
    public class BookDetails
    {
        public Book book { get; set; }
        public List<StoreExtended> storesExt { get; set; }
        public Author author { get; set; }
    }
}