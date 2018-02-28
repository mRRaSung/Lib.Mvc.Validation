using playground_20180220.Filter;
using playground_20180220.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace playground_20180220.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test(IndexViewModel model)
        {
            if(ModelState.IsValid)
            {
                return View();
            }
            return View(model);
        }



        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel
            {
                Name = "Ryan",
                Description = "Hello, Test Here",
                Number = 24
            };


            return View(model);
        }

        //public string ffff()
        //{
        //    var tc = new TaiwanCalendar();
        //    var rex = new Regex
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //ViewData["q"] = q;

            return View();
        }

        [HttpPost]
        [ModelStateExclude]
        public ActionResult About(string q, FormCollection c)
        {
            if(TryUpdateModel(c, "", c.AllKeys, ViewData["Exclude"] as string[]))
            {

            }

            ViewData["q"] = q;
            return Content(q);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}