using EFCore.SQL.Interface;
using EFCore.SQL.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiamondTrade.API
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
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.MaxDepth = 10485760; // add your desired limit here
            }); ;

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DiamondTrade.API", Version = "v1" });
            });

            services.AddScoped<IUserMaster, UserMasterRepository>();
            services.AddScoped<ICalculatorMaster, CalculatorMasterRepository>();
            services.AddScoped<IPurchaseMaster, PurchaseMasterRepository>();
            services.AddScoped<ISizeMaster, SizeMasterRepository>();
            services.AddScoped<INumberMaster, NumberMasterRepository>();
            services.AddScoped<IPriceMaster, PriceMasterRepository>();
            services.AddScoped<IPartyMaster, PartyMasterRepository>();
            services.AddScoped<IBranchMaster, BranchMasterRepository>();
            services.AddScoped<ICompanyMaster, CompanyMasterRepository>();
            services.AddScoped<IFinancialYearMaster, FinancialYearMasterRepository>();
            services.AddScoped<IPurchaseMaster, PurchaseMasterRepository>();
            services.AddScoped<ISalesMaster, SalesMasterRepository>();
            services.AddScoped<IPaymentMaster, PaymentMasterRepository>();
            services.AddScoped<IContraEntryMaster, ContraEntryMasterRespository>();
            services.AddScoped<IExpenseMaster, ExpenseMasterRepository>();
            services.AddScoped<ILoanMaster, LoanMasterRepository>();
            services.AddScoped<ISalaryMaster, SalaryMasterRepository>();
            services.AddScoped<IAccountToAssortMaster, AccountToAssortMasterRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            services.AddScoped<IRejectionInOutMaster,RejectionInOutMasterRepository>();
            services.AddScoped<IKapanMaster, KapanMasterRepository>();
            services.AddScoped<IApprovalPermissionMaster, ApprovalPermissionMasterRepository>();
            

            services.AddAuthorization(option =>
            {
                option.AddPolicy("BasicRole", policy => policy.RequireRole("Admin, Employee"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "DiamondTrade.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigins");

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
