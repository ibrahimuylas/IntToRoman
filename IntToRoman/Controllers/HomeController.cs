using IntToRoman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace IntToRoman.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View(new DataModel() { });
        }

        [HttpPost]
        public ActionResult Convert(DataModel model)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    var productDetailUrl = Url.RouteUrl(
                        "DefaultApi",
                        new { httproute = "", controller = "Values", id = model.Number },
                        Request.Url.Scheme
                    );
                    model.RomanNumber = client
                                 .GetAsync(productDetailUrl)
                                 .Result
                                 .Content.ReadAsAsync<string>().Result;

                }
            }

            return View("Index", model);
        }
    }
}
