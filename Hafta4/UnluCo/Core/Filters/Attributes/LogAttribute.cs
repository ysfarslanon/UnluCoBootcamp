using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Core.Filters.Attributes
{
    public class LogAttribute : Attribute, IActionFilter

    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // İşlem bitirildiğinde
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString();
            context.HttpContext.Response.Headers.Add("Response Time Executed", time);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // İşlem yürütülürken
            string time = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString();
            context.HttpContext.Response.Headers.Add("Response Time Executing", time);
        }
    }
}
