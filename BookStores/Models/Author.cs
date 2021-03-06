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

    public partial class Author
    {
        public int Id { get; set; }
        [RegularExpression("^[A-Z].{1,} [A-Z].{1,}$", ErrorMessage = "The First and Last Name must start with an uppercase letter and must be separated with a spacebar")]
        [Required]
        [DisplayName("Full Author Name")]
        public string Name { get; set; }
        public Nullable<System.DateTime> Born { get; set; }
        public Nullable<System.DateTime> Died { get; set; }
        [Required]
        public Nullable<bool> Gender { get; set; }
        [Required]
        [DisplayName("Image Link")]
        public string IMGLink { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayName("Select the checkbox bellow if the author is deceased")]
        public bool isDead { get; set; }
    }
}
