using System;
using System.Linq;

namespace m10.Models
{
    public interface IBookstoreRepository
    {
       IQueryable<Book> Books { get; }
    }
}
