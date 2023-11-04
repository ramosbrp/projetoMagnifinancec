using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyUniversityAPI.App_Start
{
    public class AllowCors : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");

            // Check for AJAX requests
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}