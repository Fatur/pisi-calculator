using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Pisi.Calculator;
using Pisi.CalculatorRepository;

namespace Pisi.CalculatorApi
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
            services.AddSingleton<IStaticDataRepository, DapperStaticDataRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler(
                builder =>
                {
                    builder.Run(
                    async context =>
                    {
                        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            var err = JsonConvert.SerializeObject(new Error()
                            {
                                //Stacktrace = ex.Error.StackTrace,
                                Message = ex.Error.Message

                            });
                            await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(err), 0, err.Length).ConfigureAwait(false);
                        }
                    });
                });
            app.UseMvc();
        }

        private class Error
        {
            public Error()
            {
            }
            public string Stacktrace { get; set; }
            public string Message { get; set; }
        }
    }
}
