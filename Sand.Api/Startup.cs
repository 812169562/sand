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
using Sand.Filter;
using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;

namespace Sand.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();
            services.AddOptions();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<DefaultIocConfig>();
            containerBuilder.Populate(services);
            var serviceContaniner = new ServiceContainer();
            var configuration = serviceContaniner.Configuration;
            containerBuilder.RegisterDynamicProxy(configuration, config =>
            {
                config.EnableParameterAspect();
            });
            var container = containerBuilder.Build();
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            ExceptionlessClient.Default.Configuration.ServerUrl = "http://localhost:50000";
            app.UseExceptionless("8r5ZlNo0H9cAjFkvNvQHirqHG8eAQrDhatRFVoTK");
            app.UseDeveloperExceptionPage();
            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");
            app.UseMvc();
        }
        /// <summary>
        /// autofac注入模块（扫描程序集）
        /// </summary>
        public class DefaultIocConfig : IocConfig
        {
            protected override void Load(ContainerBuilder builder)
            {
                var assemblies = new List<Assembly>();
                var dependencyContext = DependencyContext.Default;
                var libs = dependencyContext.CompileLibraries.Where(lib => !lib.Serviceable && lib.Type != "package");
                foreach (var lib in libs)
                {
                    var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                    assemblies.Add(assembly);
                }

                var typeBase = typeof(IDependency);
                builder.RegisterAssemblyTypes(assemblies.ToArray())
                    .Where(t => typeBase.IsAssignableFrom(t) && t != typeBase && !t.GetTypeInfo().IsAbstract)
                    .AsImplementedInterfaces().InstancePerLifetimeScope();
                //var typeBaseProperty = typeof(IDependencyProperty);
                //builder.RegisterAssemblyTypes(assemblies.ToArray())
                //  .Where(t => typeBase.IsAssignableFrom(t) && t != typeBase && !t.GetTypeInfo().IsAbstract)
                //  .AsImplementedInterfaces().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
            }
        }
    }
}

