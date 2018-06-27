using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStores.Models
{
    public class ListAuthor : Author
    {
        public int BookCounter { get; set; }

        public ListAuthor(Author author)
        {
            this.Born = author.Born;
            this.Description = author.Description;
            this.Died = author.Died;
            this.Gender = author.Gender;
            this.Id = author.Id;
            this.IMGLink = author.IMGLink;
            this.isDead = author.isDead;
            this.Name = author.Name;
            this.BookCounter = 0;
        }
    }
}