using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStores.Models
{
    public class BookExtended : Book
    {
        public int Price { get; set; }
        public int InStock { get; set; }

        public void CreateObject(Book book, Link link)
        {
            Id = book.Id;
            Name = book.Name;
            AuthorID = book.AuthorID;
            AuthorName = book.AuthorName;
            IMGLink = book.IMGLink;
            Description = book.Description;
            Released = book.Released;
            Price = (int)link.Price;
            InStock = (int)link.InStock;
        }
    }
}