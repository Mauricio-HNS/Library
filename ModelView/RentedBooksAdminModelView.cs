﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.ModelView
{
    public class RentedBooksAdminModelView
    {
        public int RentedBookId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Penalty { get; set; }
    }
}