using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aula_2.Controller;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Aula_2
{
    // 💀 Before you run this, install the necessary packages, or it ain't gonna fly
    // dotnet add package Microsoft.AspNetCore
    // dotnet add package SwashBuckle.AspNetCore

    public class Executar
    {
        public static void Main(string[] args)
        {
            // 🚀 Summoning the big boss: WebApplication, the heart of an ASP.NET app
            var builder = WebApplication.CreateBuilder(args);

            // 🎤 args = command-line spells you cast when running this app

            // 🔥 Gotta tell ASP.NET that we're using controllers, or it's just a sad console app
            builder.Services.AddControllers();

            // 👀 This sets up the API explorer (needed for Swagger to see the endpoints)
            builder.Services.AddEndpointsApiExplorer();

            // 📜 Swagger in the house! This makes docs so you don't have to explain APIs manually
            builder.Services.AddSwaggerGen();

            // 🏗️ Now we're building the app—time to make things real
            var app = builder.Build();

            // 🗺️ Setting up Swagger so you can flex your API documentation
            app.UseSwagger();
            app.UseSwaggerUI();

            // 🔒 Redirecting HTTP to HTTPS, 'cause security matters
            app.UseHttpsRedirection();

            // 🔑 Handling authorization (you ain't getting in without a pass)
            app.UseAuthorization();

            // 🛤️ Mapping the controllers, so the routes actually work
            app.MapControllers();

            // 🚀 **FINALLY RUNNING THE APP!** Without this, it's all just dreams 💀
            app.Run();

            //to get swagger thing, access it
            //https://localhost:5000/swagger/index.html
        }
    }
}
