using Account_Infrastructure.Repositories.Login;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using AccountInfrastructure.context;
using MediatR.Pipeline;
using Acount_Service.Features.Account;
using Account_Infrastructure.Dtos;
using Acount_Service;
using Account_Infrastructure.Repositories.Account;
using MyCM_AccountService.Midlewares;

namespace MyCM_AccountService
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
            ConfigDependencyInjection(services);
            services.AddAutoMapper(typeof(Account_Infrastructure.Mapper.Anchor).Assembly);
            services.AddMediatR(typeof(Anchor).Assembly);
            services.AddDbContext<AccountContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyCM_AccountService", Version = "v1" });
            });
        }

        private void ConfigDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCM_AccountService v1"));
            }

            app.UseTransactionMidware();

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
