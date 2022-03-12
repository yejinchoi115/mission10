using System;
using System.Linq;

namespace mission10.Models
{
    public interface IShopperRepository
    {
        IQueryable<Shopper> Shoppers { get; }

        void SaveShopper(Shopper shopper);
    }
}
