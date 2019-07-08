using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoDBServer.Application;
using ProjetoDBServer.Application.Interfaces;
using ProjetoDBServer.Application.ViewModels;
using ProjetoDBServer.Domain.Entities;
using ProjetoDBServer.Domain.Interfaces;
using ProjetoDBServer.Infra.Repository;
using Swashbuckle.AspNetCore.Swagger;

namespace ProjetoDBServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IContaCorrenteAppService, ContaCorrenteAppService>();
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContaCorrente, ContaCorrenteViewModel>();
                cfg.CreateMap<ContaCorrenteViewModel, ContaCorrente>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1", Description = "Swagger ProjetoDBServer" });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
