using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class FormsAuthenticationResource : IHttpHandler
    {
        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Cookies["Token-Auth-Forms"] != null)
            {
                context.Response.Write("Auth forms success. Token valid.");
            }
            else
            {
                context.Response.Write("Auth forms forbidden.");
            }
        }
    }
}