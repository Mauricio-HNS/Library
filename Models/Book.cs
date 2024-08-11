using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public DateTime Date { get; set; }

        public string ISBN { get; set; }

        public bool Available { get; set; }

        public Category Category { get; set; }
    }
}
