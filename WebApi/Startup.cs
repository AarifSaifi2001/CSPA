using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using WebApi.Data;
using WebApi.Helper;
using WebApi.Repository;
using WebApi.Services;

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
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<CityContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("CityApi"))
            );

            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IFuelTypeRepository, FuelTypeRepository>();
            services.AddTransient<IBodyTypeRepository, BodyTypeRepository>();
            services.AddTransient<IPhotoService, PhotoService>();

            services.AddCors(options => options.AddDefaultPolicy(
                builder => {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                }
            ));

            var SecretKey = Configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => {
                opt.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = key
                };
            });

            services.AddAutoMapper(typeof(CityMapper).Assembly);
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

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
