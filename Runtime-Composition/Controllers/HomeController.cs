using Contracts;
using Runtime_Composition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Runtime_Composition.Controllers
{
    public class HomeController : Controller
    {
        private readonly Func<string, ILanguage> _language;

        public HomeController(Func<string, ILanguage> language)
        {
            _language = language;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Language(string languageSelect)
        {
            var lang = _language(languageSelect);

            var model = new IndexModel { Message = lang.Message };

            return View("Index", model);
        }
    }
}