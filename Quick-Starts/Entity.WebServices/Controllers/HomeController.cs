using GoodToCode.Entity.WebService.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoodToCode.Entity.WebServices
{
    /// <summary>
    /// Default controller for .UseMvc
    /// </summary>
    public class HomeController : Controller
    {
        public const string ControllerName = "Home";
        public const string ContactUsView = "~/Views/GoodToCode/GoodToCode-Contact.cshtml";
        public const string IndexGetView = "~/Views/Home/Index.cshtml";
        public const string IndexGetAction = "Index";
        public const string IndexPostAction = "PostIndex";
        public const string IndexPutAction = "PutIndex";
        public const string IndexDeleteAction = "DeleteIndex";

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
        public ActionResult PostIndex()
        {
            return View(HomeController.IndexGetView);
        }

        /// <summary>
        /// Default HttpPut route
        /// </summary>
        /// <returns></returns>
        [HttpPut()]
        public ActionResult PutIndex()
        {
            return View(HomeController.IndexGetView);
        }

        /// <summary>
        /// Default HttpDelete route
        /// </summary>
        /// <returns></returns>
        [HttpDelete()]
        public ActionResult DeleteIndex()
        {
            return View(HomeController.IndexGetView);
        }

        /// <summary>
        /// Error Page
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
           return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
