using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace api
{
  public class Startup
  {
    private IConfiguration _configuration;

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers(action =>
      {
        action.ReturnHttpNotAcceptable = true;
      })
      .AddXmlDataContractSerializerFormatters()
      .AddNewtonsoftJson();

      services.AddTransient<IMailService, CloudMailService>();
      string connectionString = _configuration["connectionStrings:movieInfoDbConnectionString"];
      services.AddDbContext<MovieInfoContext>(o =>
      {
        o.UseSqlite(connectionString);
      });

      services.AddScoped<IMovieInfoRepository, MovieInfoRepository>();
      services.AddAutoMapper(typeof(Startup));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();

      });
    }
  }
}
