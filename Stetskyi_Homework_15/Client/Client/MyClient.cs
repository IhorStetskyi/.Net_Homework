using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class MyClient
    {
        static readonly HttpClient client = new HttpClient();

        public async Task GetInfo()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:8888/Information");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Info: " + responseBody);
        }
        public async Task GetSuccess()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:8888/Success");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Success: " + responseBody);
        }
        public async Task GetRedirection()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:8888/Redirection");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Redirection: " + responseBody);
        }
        public async Task GetClientError()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:8888/ClientError");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("ClientError: " + responseBody);
        }
        public async Task GetServerError()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:8888/ServerError");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("ServerError: " + responseBody);
        }
        public async Task GetHeaderName()
        {
            HttpResponseMessage response = await client.GetAsync(@"http://localhost:8888/MyNameByHeader/GetHeader");
            response.EnsureSuccessStatusCode();
            string headerName = response.Headers.GetValues("X-MyName").FirstOrDefault();
            Console.WriteLine("Header: "+headerName);
        }
        public async Task GetCookieName()
        {
            HttpResponseMessage response = await client.GetAsync(@"http://localhost:8888/MyNameByCookies/GetCookie");
            response.EnsureSuccessStatusCode();
            string cookie = response.Headers.GetValues("Set-Cookie").FirstOrDefault();
            Console.WriteLine("Cookie: " + cookie);
        }

    }
}
