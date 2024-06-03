using E_Learning.Core.Interfaces.Repositories;
using E_Learning.Core.Interfaces.Services;
using E_Learning.Core.Models;
using E_Learning.Core.Models.Identity;
using E_Learning.Error;
using E_Learning.Helper;
using E_Learning.Repository.Data;
using E_Learning.Repository.Identity;
using E_Learning.Repository.Repositories;
using E_Learning.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Collections;
using System.Reflection;
using System.Text;

namespace E_Learning
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region ConfigureService
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<LearningDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
            });




            builder.Services.AddIdentity<AppUser,IdentityRole>()
               .AddEntityFrameworkStores<LearningDbContext>()
               .AddSignInManager<SignInManager<AppUser>>().AddDefaultTokenProviders();






            builder.Services.AddSwaggerService();
            builder.Services.AddSingleton<Hashtable>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddScoped<IBasketService, BasketService>();
            builder.Services.AddScoped<IBasketRepository, BasketRepository>();
            builder.Services.AddScoped<IRepoInstructor, RepoInstructor>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddSingleton<IConnectionMultiplexer>(opt =>
            {
                var config = ConfigurationOptions.
                Parse(builder.Configuration.GetConnectionString("RedisConnection"));
                return ConnectionMultiplexer.Connect(config);
            });


            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Where(m => m.Value.Errors.Any())
                    .SelectMany(m => m.Value.Errors).Select(e => e.ErrorMessage).ToList();

                    return new BadRequestObjectResult(new ApiValidationErrorResponse() { Errors = errors });
                };
            });






            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(O =>
            {
                O.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["Jwt:Isuuer"],
                    ValidateAudience = true,

                    ValidAudience = builder.Configuration["Jwt:audience"],
                    ValidateLifetime = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ValidateIssuerSigningKey = true,
                };
            });











            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", c =>
                {
                    c.WithMethods("").AllowAnyHeader();
                });
            });


            #endregion




            
            var app = builder.Build();
            var Scope = app.Services.CreateScope();
            var Services = Scope.ServiceProvider;

            var instancemanager = Services.GetRequiredService<UserManager<AppUser>>();
            await IdentityDataContextSeed.SeedUsersAsync(instancemanager);
            #region Configure
            // Configure the HTTP request pipeline.
            //await DbInitializer.InitializaDbAsync(app);
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.UseMiddleware<CustomExceptionHandler>();
            #endregion


            app.Run();
        }
    }
}
