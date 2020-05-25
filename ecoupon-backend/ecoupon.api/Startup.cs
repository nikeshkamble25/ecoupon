using System;
using AutoMapper;
using ecoupon.data;
using ecoupon.repository.contracts;
using ecoupon.repository.implementations;
using ecoupon.mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ecoupon.api
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
            services.AddDbContext<EcouponContext>(x => x.UseNpgsql("Host=database;Database=ecoupon;Username=postgres;Password=postgres", b => b.MigrationsAssembly("ecoupon.api")));
            services.AddControllers();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(Startup).Assembly);
            IMapper mapper = EcouponMapperConfiguration.Configure();
            services.AddSingleton(mapper);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}