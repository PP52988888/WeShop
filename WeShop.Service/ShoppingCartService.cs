using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeShop.IRepository;
using WeShop.IService;
using WeShop.EFModel;

namespace WeShop.Service
{
    public class ShoppingCartService : BaseService<ShoppingCart>, IShoppingCartService
    {
        public ShoppingCartService(IShoppingCartRepository ShoppingCartrepository) : base(ShoppingCartrepository)
        {
        }
    }
}
