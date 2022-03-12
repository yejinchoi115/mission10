using System;
using System.Linq;

namespace mission10.Models
{
    public interface IBookstoreRepository
    {
       IQueryable<Book> Books { get; }
    }
}
