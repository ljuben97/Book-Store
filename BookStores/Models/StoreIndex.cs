using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStores.Models
{
    public class StoreIndex : Store
    {
        public int BookCounter { get; set; }

        public StoreIndex(Store store)
        {
            this.Description = store.Description;
            this.Id = store.Id;
            this.IMGLink = store.IMGLink;
            this.Name = store.Name;
            this.Opened = store.Opened;
            this.BookCounter = 0;
        }
    }
}