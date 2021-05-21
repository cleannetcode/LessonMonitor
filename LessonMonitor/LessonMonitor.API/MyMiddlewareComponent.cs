using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace LessonMonitor.API
{
    public class MyMiddlewareComponent
    {
        private readonly RequestDelegate _next;

        public MyMiddlewareComponent(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            using (FileStream fs = new FileStream(@"..\filelogFromClass.txt", FileMode.OpenOrCreate))
            {
                fs.Write(Encoding.Default.GetBytes("Request:" + "\n"));
                fs.Write(Encoding.Default.GetBytes("Header:      " + context.Request.Headers.ToString() + "\n"));
                fs.Write(Encoding.Default.GetBytes("Host:        " + context.Request.Host.ToString() + "\n"));
                fs.Write(Encoding.Default.GetBytes("HttpContext: " + context.Request.HttpContext.ToString() + "\n"));
                fs.Write(Encoding.Default.GetBytes("IsHttps:     " + context.Request.IsHttps.ToString() + "\n"));
                fs.Write(Encoding.Default.GetBytes("Method:      " + context.Request.Method.ToString() + "\n"));
                fs.Write(Encoding.Default.GetBytes("Path:        " + context.Request.Path.ToString() + "\n"));
                fs.Write(Encoding.Default.GetBytes("Protocol:    " + context.Request.Protocol.ToString() + "\n"));
                fs.Write(Encoding.Default.GetBytes("Scheme:      " + context.Request.Scheme.ToString() + "\n"));

                fs.Write(Encoding.Default.GetBytes("\n" + "Response:" + "\n"));
                fs.Write(Encoding.Default.GetBytes("Header:      " + context.Response.Headers.ToString() + "\n"));
                fs.Write(Encoding.Default.GetBytes("StatusCode:  " + context.Response.StatusCode.ToString() + "\n"));
                fs.Write(Encoding.Default.GetBytes("HttpContext: " + context.Response.HttpContext.ToString() + "\n"));
                fs.Write(Encoding.Default.GetBytes("HasStarted:  " + context.Response.HasStarted.ToString() + "\n"));
                fs.Write(Encoding.Default.GetBytes("Body:        " + context.Response.Body.ToString() + "\n"));
            }

            return _next(context);
        }
    }
}
