using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Biblioteca.ModelView
{
    public class BookCreateModelView
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        //[Index(IsUnique = true)]
        public int ISBN { get; set; }
        public bool Available { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}