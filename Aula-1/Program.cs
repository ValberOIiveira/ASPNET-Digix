using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace aspnet
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona suporte para arquivos estáticos
            builder.Services.AddDirectoryBrowser();  // Se quiser navegar pelos arquivos

            var app = builder.Build();

            // Configura o ambiente
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Habilita o uso de arquivos estáticos (wwwroot)
            app.UseStaticFiles();

            app.UseRouting();

            // Configura a rota para o arquivo HTML
            app.MapGet("/", () => Results.Redirect("/index.html"));

            app.Run();
        }
    }
}
