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

    public partial class Book
    {
        [DisplayName("Select the book you want to add")]
        public int Id { get; set; }
        [Required]
        [DisplayName("Book Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Image Link")]
        public string IMGLink { get; set; }
        [Required]
        [DisplayName("Year Released")]
        [Range(1, 2018, ErrorMessage ="The Year Released field can't be a negative number")]
        public Nullable<int> Released { get; set; }
        [DisplayName("Select The Author")]
        public Nullable<int> AuthorID { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayName("Author Name")]
        public string AuthorName { get; set; }
    }
}
