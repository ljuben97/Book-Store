using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStores.Models
{
    public class StoreDetails
    {
        public Store store { get; set; }
        public List<BookExtended> books { get; set; }
    }
}