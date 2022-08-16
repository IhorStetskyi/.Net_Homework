using System;
using System.IO;
using System.Net;
using System.Text;

namespace Listener
{
    class MyListener
    {
        public HttpListener listener;
        public MyListener()
        {
            listener = new HttpListener();
            string prefix1 = "http://localhost:8888/";
            listener.Prefixes.Add(prefix1);
        }

        public void StartListening()
        {
            listener.Start();
            Console.WriteLine("Listening");
            while (true)
            {
                GetMyName(listener.GetContext());
            }
        }
        public void StopListening()
        {
            listener.Stop();
        }

        public void GetMyName(HttpListenerContext ctx)
        {
            string? path = ctx.Request.Url?.LocalPath;

            switch (path)
            {
                case "/Information":
                    Information(ctx);
                    break;
                case "/Success":
                    Success(ctx);
                    break;
                case "/Redirection":
                    Redirection(ctx);
                    break;
                case "/ClientError":
                    ClientError(ctx);
                    break;
                case "/ServerError":
                    ServerError(ctx);
                    break;
                case "/MyNameByHeader/GetHeader":
                    GetMyNameByHeader(ctx);
                    break;
                case "/MyNameByCookies/GetCookie":
                    MyNameByCookies(ctx);
                    break;
                default:
                    break;
            }
        }

        public void Information(HttpListenerContext ctx)
        {
            using HttpListenerResponse resp = ctx.Response;
            resp.Headers.Set("Content-Type", "text/plain");
            Console.WriteLine("Sent Information Response");

            byte[] buf = Encoding.UTF8.GetBytes("1xx – Information");
            resp.ContentLength64 = buf.Length;

            using Stream ros = resp.OutputStream;
            ros.Write(buf, 0, buf.Length);
        }
        public void Success(HttpListenerContext ctx)
        {
            using HttpListenerResponse resp = ctx.Response;
            resp.Headers.Set("Content-Type", "text/plain");
            Console.WriteLine("Sent Success Response");

            byte[] buf = Encoding.UTF8.GetBytes("2xx – Success");
            resp.ContentLength64 = buf.Length;

            using Stream ros = resp.OutputStream;
            ros.Write(buf, 0, buf.Length);
        }
        public void Redirection(HttpListenerContext ctx)
        {
            using HttpListenerResponse resp = ctx.Response;
            resp.Headers.Set("Content-Type", "text/plain");
            Console.WriteLine("Sent Redirection Response");

            byte[] buf = Encoding.UTF8.GetBytes("3xx – Redirection");
            resp.ContentLength64 = buf.Length;

            using Stream ros = resp.OutputStream;
            ros.Write(buf, 0, buf.Length);
        }
        public void ClientError(HttpListenerContext ctx)
        {
            using HttpListenerResponse resp = ctx.Response;
            resp.Headers.Set("Content-Type", "text/plain");
            Console.WriteLine("Sent ClientError Response");

            byte[] buf = Encoding.UTF8.GetBytes("4xx – Client error");
            resp.ContentLength64 = buf.Length;

            using Stream ros = resp.OutputStream;
            ros.Write(buf, 0, buf.Length);
        }
        public void ServerError(HttpListenerContext ctx)
        {
            using HttpListenerResponse resp = ctx.Response;
            resp.Headers.Set("Content-Type", "text/plain");
            Console.WriteLine("Sent ServerError Response");

            byte[] buf = Encoding.UTF8.GetBytes("5xx – Server error");
            resp.ContentLength64 = buf.Length;

            using Stream ros = resp.OutputStream;
            ros.Write(buf, 0, buf.Length);
        }
        public void GetMyNameByHeader(HttpListenerContext ctx)
        {
            using HttpListenerResponse resp = ctx.Response;
            Console.WriteLine("Sent Header Response");
            resp.Headers.Set("Content-Type", "text/plain");
            resp.Headers.Set("X-MyName", "Header Name");


            byte[] buf = Encoding.UTF8.GetBytes("Some Else Text");
            resp.ContentLength64 = buf.Length;

            using Stream ros = resp.OutputStream;
            ros.Write(buf, 0, buf.Length);
        }
        public void MyNameByCookies(HttpListenerContext ctx)
        {
            using HttpListenerResponse resp = ctx.Response;
            Console.WriteLine("Sent Cookie Response");
            resp.Headers.Set("Content-Type", "text/plain");

            Cookie cookie = new Cookie("MyName", "Cookie Name");
            Cookie cookie2 = new Cookie("MyName2", "Cookie Name2");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            cookie2.Expires = DateTime.Now.AddMinutes(1);
            resp.Cookies.Add(cookie);
            resp.Cookies.Add(cookie2);

            byte[] buf = Encoding.UTF8.GetBytes("Some Else Text");
            resp.ContentLength64 = buf.Length;

            using Stream ros = resp.OutputStream;
            ros.Write(buf, 0, buf.Length);
        }
    }
}
