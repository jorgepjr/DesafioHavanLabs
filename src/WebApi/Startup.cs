using Adaptadores;
using Adaptadores.Persistencias;
using CasosDeUso.ClientApi;
using CasosDeUso.Clientes;
using CasosDeUso.Interfaces;
using Dominio.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Refit;
using System;

namespace WebApi
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
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new OpenApiInfo { Title = "API Vendas", Version = "v1" });
            });

            //services.AddDbContext<Contexto>(x => x.UseInMemoryDatabase("Memo"));

            services.AddDbContext<Contexto>(x => x.UseNpgsql(Configuration.GetConnectionString("Contexto"), x => x.MigrationsAssembly("WebApi")));

            //Refit
            services.AddRefitClient<IApiViaCep>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(Configuration["UrlViaCep"]));


            //Persistencias
            services.AddScoped<IPersistenciaDoCliente, PersistenciaDoCliente>();
            services.AddScoped<IPersistenciaDoProduto, PersistenciaDoProduto>();
            services.AddScoped<IPersistenciaDaPreVenda, PersistenciaDaPreVenda>();


            services.AddScoped<ICadastroDoCliente, CadastroDoCliente>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("../swagger/v1/swagger.json", "API Vendas");
                options.RoutePrefix = "documentacao";
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
