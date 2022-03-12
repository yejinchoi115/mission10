using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace mission10.Models
{
    public class EFBookstoreRepository: IBookstoreRepository
    {
        private BookstoreContext context { get; set; }
        public EFBookstoreRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => (IQueryable<Book>)context.Books;
    }
}
