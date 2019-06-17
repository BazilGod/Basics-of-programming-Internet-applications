using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1
{
    public class FormsAuthHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.ContentLength > 0)
            {
                byte[] byteContent = new byte[context.Request.ContentLength];
                context.Request.InputStream.Read(byteContent, 0, byteContent.Length);
                string content = Encoding.UTF8.GetString(byteContent);
                string username = content.Substring(0, content.IndexOf('&'));
                string password = content.Substring(content.IndexOf('&')+1);
                if (username.Substring(username.IndexOf('=') + 1) == "bazil" && password.Substring(password.IndexOf('=') + 1) == "bazil")
                {

                    Random random = new Random();
                    int id = random.Next(1000, 100000000);
                    context.Response.SetCookie(new HttpCookie("Token-Auth-Forms", id.ToString()));
                    context.Response.Redirect("http://localhost:65128/res.resource");
                }
                else {
                    context.Response.Redirect("http://localhost:65128/res.resource");
                }
            }
        

        }
    }
}