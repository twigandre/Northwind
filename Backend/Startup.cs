using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Northwind.Database.Repository;
using Northwind.Database.Models;
using Northwind.BusinnesLogic.Pedido;
using System;
using Northwind.Database;
using Northwind.BusinnesLogic.Colaboradores;
using Microsoft.EntityFrameworkCore;
using Northwind.BusinnesLogic.Produto;

namespace Northwind
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
            services.AddCors();

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Northwind", Version = "v1" });
            });

            #region DataBase Configurations
            services.AddEntityFrameworkNpgsql()
            .AddDbContext<NorthwindContext>(options =>
                                            options.UseNpgsql("Host=" + Environment.GetEnvironmentVariable("HOST_DATABASE") + ";" +
            "                                                  Port=" + Environment.GetEnvironmentVariable("DATABASE_PORT") + ";" +
            "                                                  Database=" + Environment.GetEnvironmentVariable("DATABASE_NAME") + ";" +
            "                                                  Username=" + Environment.GetEnvironmentVariable("DATABASE_USER") + ";" +
            "                                                  Password=" + Environment.GetEnvironmentVariable("DATABSE_PSW") + ";" +
            "                                                  timeout=300"));
            #endregion

            #region Dependency Injection - Entity Repositories
            services.AddScoped<IRepository<Category>, EntityRepository<Category>>();
            services.AddScoped<IRepository<Customer>, EntityRepository<Customer>>();
            services.AddScoped<IRepository<CustomerCustomerDemo>, EntityRepository<CustomerCustomerDemo>>();
            services.AddScoped<IRepository<CustomerDemographic>, EntityRepository<CustomerDemographic>>();
            services.AddScoped<IRepository<Employee>, EntityRepository<Employee>>();
            services.AddScoped<IRepository<EmployeeTerritory>, EntityRepository<EmployeeTerritory>>();
            services.AddScoped<IRepository<Order>, EntityRepository<Order>>();
            services.AddScoped<IRepository<OrderDetail>, EntityRepository<OrderDetail>>();
            services.AddScoped<IRepository<Product>, EntityRepository<Product>>();
            services.AddScoped<IRepository<Region>, EntityRepository<Region>>();
            services.AddScoped<IRepository<Shipper>, EntityRepository<Shipper>>();
            services.AddScoped<IRepository<Supplier>, EntityRepository<Supplier>>();
            services.AddScoped<IRepository<Territory>, EntityRepository<Territory>>();
            services.AddScoped<IRepository<UsState>, EntityRepository<UsState>>();
            #endregion

            #region Dependency Injection - BusinessLogic
            services.AddScoped<IColaboradoresBll, ColaboradoresBll>();
            services.AddScoped<IPedidoBll, PedidoBll>();
            services.AddScoped<IProdutoBll, ProdutoBll>();
            #endregion

            services.AddControllers();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
