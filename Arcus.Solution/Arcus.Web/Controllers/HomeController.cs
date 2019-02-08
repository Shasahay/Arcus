using Arcus.Web.Infra.ActionResults.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arcus.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new HomePageViewModelActionResult<HomeController>(x => x.Index());    
        }

        public ActionResult Category(string categoryName)
        {
            return new CategoryViewModelActionResult<HomeController>(x => x.Category(categoryName), categoryName);
        }

        public ActionResult Details(int id)
        {
            return new DetailsViewModelActionResult<HomeController>(x => x.Details(id), id);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}