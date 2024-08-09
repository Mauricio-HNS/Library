using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public int ISBN { get; set; }
        public bool Available { get; set; }
    }
}