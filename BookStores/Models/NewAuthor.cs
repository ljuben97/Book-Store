using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStores.Models
{
    public class NewAuthor
    {
        public Author author { get; set; }

        [DisplayName("Year")]
        [Required]
        public String birthYear { get; set; }
        [Required]
        [DisplayName("Month")]
        public String birthMonth { get; set; }
        [Required]
        [DisplayName("Date")]
        public String birthDate { get; set; }

        [DisplayName("Year")]
        public String deathYear { get; set; }
        [DisplayName("Month")]
        public String deathMonth { get; set; }
        [DisplayName("Date")]
        public String deathDate { get; set; }
    }
}