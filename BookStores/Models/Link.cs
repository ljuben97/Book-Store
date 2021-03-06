//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStores.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Link
    {
        public int Id { get; set; }
        public Nullable<int> StoreID { get; set; }
        [DisplayName("Select a book")]
        public Nullable<int> BookID { get; set; }
        [DisplayName("Enter the price for the book")]
        [Range(1, 100, ErrorMessage ="The price of the book must be between 1 and 100 dollars")]
        [Required(ErrorMessage ="You must enter a price")]
        public Nullable<int> Price { get; set; }
        [Required(ErrorMessage ="You must enter the quantity of books")]
        [DisplayName("Enter how many books will be up fo purchase")]
        public Nullable<int> InStock { get; set; }
    }
}
