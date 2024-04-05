using ExamenUnidad2.Database;
using ExamenUnidad2.Services;
using ExamenUnidad2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExamenUnidad2
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices (IServiceCollection services)
        {
            services.AddControllers ();

            services.AddDbContext<IMCDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IIMCServices, IMCServices>();

            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:5173/")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
