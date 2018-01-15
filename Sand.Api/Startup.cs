using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Sand.Dependency;
using Sand.DI;
using AspectCore.Extensions.Autofac;
using NLog.Extensions.Logging;
using NLog.Web;
using Exceptionless;
using AspectCore.Injector;
using AspectCore.DynamicProxy.Parameters;
using Microsoft.Extensions.Configuration;
using Sand.Domain.Uow;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Exceptionless.Json;
using Sand.Log.Extensions;
using Sand.Context;
using Swashbuckle.AspNetCore.Swagger;

namespace Sand.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            //var builder = new ConfigurationBuilder()
            //.SetBasePath(env.ContentRootPath)
            //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();
            services.AddCors(options => options.AddPolicy("any", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddOptions();
            DefaultIocConfig.ContainerBuilder.RegisterType<WebContext>().As<IContext>().AsImplementedInterfaces().SingleInstance();
            DefaultIocConfig.ContainerBuilder.AddNLog();
            DefaultIocConfig.ContainerBuilder.RegisterModule<DefaultIocConfig>();
            DefaultIocConfig.ContainerBuilder.RegisterType<MySqlConfig>().As<ISqlConfig>().AsImplementedInterfaces().SingleInstance();
            DefaultIocConfig.ContainerBuilder.Populate(services);
            DefaultIocConfig.ContainerBuilder.RegisterDynamicProxy(config =>
            {
                config.EnableParameterAspect();
            });
            DefaultIocConfig.Container = DefaultIocConfig.ContainerBuilder.Build();
            return DefaultIocConfig.Container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");
            ExceptionlessClient.Default.Configuration.ServerUrl = "http://localhost:50000";
            app.UseExceptionless("8r5ZlNo0H9cAjFkvNvQHirqHG8eAQrDhatRFVoTK");
            app.UseDeveloperExceptionPage();
            app.UseErrorHandling();
            app.UseMvc();
            app.UseSwagger();

            //Enable middleware to serve swagger - ui(HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var statusCode = context.Response.StatusCode;
                if (ex is ArgumentException)
                {
                    statusCode = 200;
                }
                await HandleExceptionAsync(context, statusCode, ex.Message);
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                var msg = "";
                if (statusCode == 401)
                {
                    msg = "未授权";
                }
                else if (statusCode == 404)
                {
                    msg = "未找到服务";
                }
                else if (statusCode == 502)
                {
                    msg = "请求错误";
                }
                else if (statusCode != 200)
                {
                    msg = "未知错误";
                }
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    await HandleExceptionAsync(context, statusCode, msg);
                }
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, int statusCode, string msg)
        {
            var data = new { code = statusCode.ToString(), is_success = false, msg = msg };
            var result = JsonConvert.SerializeObject(new { data = data });
            context.Response.ContentType = "application/json;charset=utf-8";
            return context.Response.WriteAsync(result);
        }
    }
    public static class ErrorHandlingExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}

