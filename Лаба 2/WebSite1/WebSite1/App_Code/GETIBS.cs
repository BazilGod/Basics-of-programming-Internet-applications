using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class GETIBS: IHttpHandler
{
    public bool IsReusable
    {
        get { return false; }
    }

    public void ProcessRequest(HttpContext context)
    {
        HttpRequest req = context.Request;
        HttpResponse res = context.Response;
        res.AddHeader("X-IBS", "Bazil Ikonov");
        res.Write("<html><head>" +
            "<link rel=\"stylesheet\" href='CSS1IBS.css'>" +
            "<link rel=\"stylesheet\" href = 'CSS2IBS.css'>" +
            "<script type=\"text/javascript\" src=\"JS1IBS.js\"> </script>" +
            "<p><a href = \"HtmlIBS.html\" class=\"o\"> Статический HTML </a></p>" +
            "<script type=\"text/javascript\" src=\"JS2IBS.js\"> </script>" +
            "<title>GETIBS</title></head><body>" +
            "<img src = \"b.jpg\" >" +
            "<form method = \"post\" action = \"http://localhost:50371/asd.IBS\">" +
            "<input type = \"checkbox\" checked name = \"check\"/> <br />" +
            "<input type = \"radio\" cheked name = \"radio\" /> <br />" +
            "<p calss=\"text\"> <b >POST: <b > <br/>" +
            "<input type = \"text\" name = \"text\" /> <br/>" +
            "<input type = \"submit\" value= \"ok\" name = \"butt\" /> <br/>" +
            "</form>" + "<h1>" +
            req.QueryString["getIBSparam"] + "</h1>" + "</body></html>" 
            );
    
    }
}