using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Library.CoreApi_20220105.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }


        public string Description { get; set; }
        public string Edition { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
