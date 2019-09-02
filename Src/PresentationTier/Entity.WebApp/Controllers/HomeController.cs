using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GoodToCode.Entity.WebApp
{
    public class HomeController : Controller
    {
        public const string ControllerName = "Home";
        public const string IndexGetView = "~/Pages/Home/Index.cshtml";
        public const string IndexGetAction = "Index";
        public const string IndexPostAction = "IndexPost";
        public const string IndexPutAction = "IndexPut";
        public const string IndexDeleteAction = "IndexDelete";

        /// <summary>
        /// Default HttpGet route
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult Index()
        {
            return View(HomeController.IndexGetView);
        }

        /// <summary>
        /// Default HttpPost route
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        public ActionResult IndexPost()
        {
            return View(HomeController.IndexGetView);
        }

        /// <summary>
        /// Default HttpPut route
        /// </summary>
        /// <returns></returns>
        [HttpPut()]
        public ActionResult IndexPut()
        {
            return View(HomeController.IndexGetView);
        }

        /// <summary>
        /// Default HttpDelete route
        /// </summary>
        /// <returns></returns>
        [HttpDelete()]
        public ActionResult IndexDelete()
        {
            return View(HomeController.IndexGetView);
        }
    }
}
