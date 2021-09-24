using System;
using BebidasStore.DbContextos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BebidasStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var escopo = host.Services.CreateScope())
            {
                try
                {
                    var contexto = escopo.ServiceProvider.GetService<BebidasStoreContexto>();
                    contexto.Database.EnsureDeleted();
                    contexto.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = escopo.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Ocorreu um erro ao migrar o banco de dados.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
