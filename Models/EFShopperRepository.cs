using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace m10.Models
{
    public class EFShopperRepository : IShopperRepository
    {

        private BookstoreContext context;

        public EFShopperRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Shopper> Shoppers => context.Shoppers;

        public void SaveShopper(Shopper shopper)
        {
            context.AttachRange(shopper.Lines.Select(x => x.Book));

            if (shopper.ShopperId == 0)
            {
                context.Shoppers.Add(shopper);
            }

            context.SaveChanges();
        }
    }
}
