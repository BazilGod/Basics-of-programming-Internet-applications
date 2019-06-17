using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Lab05
{
    public class get : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string head = context.Request.Headers["Authorization"];

            if (head != null)
            {
                string login2="bazil";
                string password2="bazil";
                var base64Encoded = head.Replace("Basic ", "");
                string information = Encoding.UTF8.GetString(Convert.FromBase64String(base64Encoded));
                string[] i = information.Split(':');
                string login = i[0];
                string password = i[1];
                context.Response.StatusCode = 200;
                if (login2 == login && password2 == password)
                {
                    context.Response.Write($"login: {login} <br> password: {password}");
                }
            }
            else
            {
                context.Response.Headers.Add("WWW-Authenticate", "Basic");
                context.Response.StatusCode = 401;
                context.Response.End();
            }
        }
    }
}