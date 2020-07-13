using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RepoDb.Interfaces;

namespace RepoDb.Demo
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
            services.AddControllers();

            SqlServerBootstrap.Initialize();

            var connection = Configuration.GetValue<string>("ConnectionString");
            services.AddSingleton(new WarehouseRepository(connection));

            services.AddSingleton<IWarehouseObjectRepo>(new WarehouseObjectRepo(connection));

            services.AddSingleton<IWarehouseInlineRepo>(new WarehouseInlineRepo(connection));

            services.AddSingleton<IWarehouseProcedureRepo>(new WarehouseProcedureRepo(connection));

            services.AddSingleton<IWarehouseProvider>(c =>
                new WarehouseProvider(connection, c.GetService<ICache>()));

            services.AddSingleton<IWareHouseUpdator>(c =>
                new WareHouseUpdator(connection, c.GetService<ITrace>()));

            services.AddSingleton<IWareHouseDeletor>(new WareHouseDeletor(connection));

            services.AddSingleton<ICache, MemoryCache>();
            services.AddSingleton<ITrace, CustomTrace>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
