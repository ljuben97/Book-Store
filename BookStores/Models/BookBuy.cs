using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStores.Models
{
    public class BookBuy
    {
        public BookIndex bookExtended { get; set; }
        public Store store { get; set; }

        public int InStock { get; set; }
        [Required(ErrorMessage ="You must enter the amount of books you want to buy")]
        [DisplayName("Enter how many book would you like to buy")]
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}