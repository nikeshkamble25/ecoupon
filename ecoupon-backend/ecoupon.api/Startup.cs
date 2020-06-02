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
using ecoupon.api.Hub;
using Microsoft.AspNetCore.SignalR;

namespace ecoupon.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EcouponContext>(x => x.UseNpgsql("Host=database-cluster-ip-service;Database=ecoupon;Username=postgres;Password=postgres", b => b.MigrationsAssembly("ecoupon.api")));
            services.AddControllers();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(Startup).Assembly);
            IMapper mapper = EcouponMapperConfiguration.Configure();
            services.AddSignalR();
            services.AddCors();
            services.AddSingleton(mapper);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        );

            app.UseRouting();
            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<BroadcastHub>("/notify");
            });
        }
    }
}