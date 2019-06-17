using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class POSTIBS : IHttpHandler
{
    public bool IsReusable
    {
        get { return false; }
    }

    public void ProcessRequest(HttpContext context)
    {
        HttpRequest rq = context.Request;
        HttpResponse rs = context.Response;
        rs.Write("radio=" + rq.Params["radio"] + "<br/>" +
            "check=" + rq.Params["check"] + "<br/>" +
            "text=" + rq.Params["text"] + "<br/>" +
            "button=" + rq.Params["butt"] + "<br/>"
            );
        string[] k = rq.Headers.AllKeys;
        rs.Write("<h1> Headers <h1/> <br/>");
        foreach (var key in k)
        {
            rs.Write("<h5>" + key + " = " + rq.Headers[key] + "<h5/>");
        }

        string[] pk = rq.Params.AllKeys;
        rs.Write("<h1> Params<h1/><br/>");
        foreach (var key in pk)
        {
            rs.Write("<h5>" + key + " = " + rq.Params[key] + "<h5/>");
        }
    }
}