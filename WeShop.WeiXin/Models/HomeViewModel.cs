using System.Collections.Generic;
using WeShop.EFModel;

namespace WeShop.WeiXin.Models
{
    public class HomeViewModel
    {
        public int NoticeNum { get; set; }
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<Notice> Notice { get; set; }

        public IEnumerable<Product> NewProduct { get; set; }
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Sort> Sort { get; set; }
        public IEnumerable<ProReview> ProReview { get; set; }
    }
}