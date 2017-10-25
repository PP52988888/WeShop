using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeShop.IService;
using WeShop.EFModel;
using WeShop.IRepository;

namespace WeShop.Service
{
    public class BannerService : BaseService<Banner>, IBannerService
    {
        public BannerService(IBannerRepository  bannerepository) : base(bannerepository)
        {
        }
    }
}
