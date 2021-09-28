using EF_DEMO.DataContext;
using EF_DEMO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EF_DEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add new item?");
            Console.ReadKey();
            var context = new AppDbContext();
            var user = new User()
            {
                UserName = "Gacek2"
            };
            context.Users.Add(user);
            context.SaveChanges();
            Console.WriteLine("New item added");
            Console.ReadKey();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "server=127.0.0.1;user=root;password=sosNa;database=test";

            services.AddDbContext<AppDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString)
                    .EnableSensitiveDataLogging()
            );
        }
    }
}
