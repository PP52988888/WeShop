using System;
using System.Web.Mvc;
using WeShop.EFModel;
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
        public IShoppingCartService ShoppingCartService { get; set; }
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
            Session["Custid"] = 1;
            return View(homeviewmodel);
        }

        public ActionResult AddCat(string prcode,int prodqty)
        {
            ShoppingCart shoppcat = new ShoppingCart();
                var shopping  = ShoppingCartService.GetEntity(s => s.CusId == (int) Session["Custid"] && s.ProCode == prcode);
            bool result;
            if (shopping == null)
            {
                shoppcat.CusId = 1;
                shoppcat.ProCode = prcode;
                shoppcat.Qty = prodqty;
                shoppcat.CreateTime = DateTime.Now;

                result = ShoppingCartService.Add(shoppcat);
            }
            else
            {
                shopping.Qty += prodqty;
                result = ShoppingCartService.Modify(shopping);
            }
            string msg= result ? "ok" : "no";

            return Json(msg);
        }
    }
}