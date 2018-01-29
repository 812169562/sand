using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
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
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;

using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace Sand.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
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
                c.SwaggerDoc("v1", new Info { Title = "My API",
                });
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //var xmlPath = Path.Combine(basePath, "Sand.Api.xml");
                //c.IncludeXmlComments(xmlPath);
                //c.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
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
            //app.UseErrorHandling();
            app.UseSwagger();

            //Enable middleware to serve swagger - ui(HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
   
    public class HttpHeaderOperation : IOperationFilter
    {
        /// <summary>
        /// 实现接口
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }

            var actionAttrs = context.ApiDescription.ActionAttributes();

            var isAuthorized = actionAttrs.Any(a => a.GetType() == typeof(AuthorizeAttribute));

            if (isAuthorized == false) //提供action都没有权限特性标记，检查控制器有没有
            {
                var controllerAttrs = context.ApiDescription.ControllerAttributes();

                isAuthorized = controllerAttrs.Any(a => a.GetType() == typeof(AuthorizeAttribute));
            }

            var isAllowAnonymous = actionAttrs.Any(a => a.GetType() == typeof(AllowAnonymousAttribute));

            if (isAuthorized && isAllowAnonymous == false)
            {
                operation.Parameters.Add(new NonBodyParameter()
                {
                    Name = "Authorization",  //添加Authorization头部参数
                    In = "header",
                    Type = "string",
                    Required = false
                });
            }
        }
    }
}

