using System;
using System.Linq;

namespace m10.Models
{
    public interface IShopperRepository
    {
        IQueryable<Shopper> Shoppers { get; }

        void SaveShopper(Shopper shopper);
    }
}
