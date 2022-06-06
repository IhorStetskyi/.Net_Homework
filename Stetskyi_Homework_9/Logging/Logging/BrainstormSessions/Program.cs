using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using log4net;
using System.Reflection;
using log4net.Config;
using System.IO;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using System.Net;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
            //.WriteTo.Console()
            //.WriteTo.Email(new EmailConnectionInfo
            //{
            //    FromEmail = "onemangamestudio2015@gmail.com",
            //    ToEmail = "onemangamestudio2015@gmail.com",
            //    MailServer = "smtp.gmail.com",
            //    NetworkCredentials = new NetworkCredential
            //    {
            //        UserName = "onemangamestudio2015@gmail.com",
            //        Password = "{HereSHouldBePassword}"
            //    },
            //    EnableSsl = true,
            //    Port = 587,
            //    EmailSubject = "Some Subject"
            //},
            //    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}",
            //    batchPostingLimit: 10
            //    , restrictedToMinimumLevel: LogEventLevel.Verbose
            //)
            //.CreateLogger();

            Log.Logger = new LoggerConfiguration().CreateLogger();
            var logrepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logrepository, new FileInfo("log4net.config"));

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((hostingContext, loggerConfiguration) =>
                loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
