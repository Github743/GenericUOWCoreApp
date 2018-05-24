using AutoMapper;
using CoreApp.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CoreApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<DataModelMappingProfile>();
            });
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
