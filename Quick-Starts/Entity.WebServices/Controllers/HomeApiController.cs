using Microsoft.AspNetCore.Mvc;
using System;

namespace GoodToCode.Entity.WebServices
{
    /// <summary>
    /// Default WebApi controller
    /// </summary>
    [Route(ControllerRoute)]
    public class HomeApiController : ControllerBase
    {
        public const string ControllerName = "HomeApi";
        public const string ControllerRoute = "v4/HomeApi";
        public const string IndexGetAction = "Get";
        public const string IndexPutAction = "Put";
        public const string IndexPostAction = "Post";
        public const string IndexDeleteAction = "Delete";

        /// <summary>
        /// Default HttpGet route
        /// </summary>
        /// <returns></returns>
        [HttpGet()]        
        public string Get()
        {
            return $"[{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}] {"Services up and running..."}";
        }

        /// <summary>
        /// Default HttpPost route
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        public string Post()
        {
            return $"[{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}] {"Services up and running..."}";
        }

        /// <summary>
        /// Default HttpPut route
        /// </summary>
        /// <returns></returns>
        [HttpPut()]
        public string Put()
        {
            return $"[{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}] {"Services up and running..."}";
        }

        /// <summary>
        /// Default HttpDelete route
        /// </summary>
        /// <returns></returns>
        [HttpDelete()]
        public string Delete()
        {
            return $"[{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}] {"Services up and running..."}";
        }
    }
}
