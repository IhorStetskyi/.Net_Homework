using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            MyClient client = new MyClient();
            await client.GetInfo();
            await client.GetSuccess();
            await client.GetRedirection();
            await client.GetClientError();
            await client.GetServerError();
            await client.GetHeaderName();
            await client.GetCookieName();
        }
    }
       
}
