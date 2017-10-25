using System.Web.Mvc;
using WeShop.IService;
using WeShop.WeiXin.Models;

namespace WeShop.WeiXin.Controllers
{
    public class HomeController : Controller
    {
        public IBannerService BannerService { get; set; }
        public INoticeService NoticeService { get; set; }
        public IProductService ProductService { get; set; }
        public ISortService SortService { get; set; }
        public IProReviewService ProReviewService { get; set; }
        private HomeViewModel homeviewmodel = new Models.HomeViewModel();

        // GET: Home
        public ActionResult Index()
        {
            homeviewmodel.Banners = BannerService.GetEntities(b => true);
            homeviewmodel.NoticeNum = NoticeService.GetCount(b => true);
            homeviewmodel.Notice = NoticeService.GetEntitiesByPage(3, 1, false, n => true, n => n.ModiTime);
            homeviewmodel.NewProduct = ProductService.GetEntitiesByPage(5, 1, false, n => n.Type == 1 && n.Grounding == true, n => n.ModiTime);
            return View(homeviewmodel);
        }

        public ActionResult ListProduct()
        {
            homeviewmodel.Sort = SortService.GetEntities(s => true);
            return View(homeviewmodel);
        }

        public ActionResult Search_list(int code)
        {
            if (code == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            homeviewmodel.Product = SortService.GetEntity(s => s.Code == code).Products;
            return View(homeviewmodel);
        }

        public ActionResult Product(string procode)
        {
            if (string.IsNullOrEmpty(procode))
            {
                return RedirectToAction("Index", "Home");
            }
            homeviewmodel.Product = ProductService.GetEntities(p => p.Code == procode);
            ///这里还没有写全，缺少个查询条件（评价状态）
            homeviewmodel.ProReview = ProReviewService.GetEntities(p => p.ProCode == procode);
            return View(homeviewmodel);
        }
    }
}