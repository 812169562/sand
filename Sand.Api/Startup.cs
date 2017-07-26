﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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
using Sand.Domain.Uow;
using Sand.Domain.Entities;
using Sand.Service;

namespace Sand.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<DefaultIocConfig>();
            containerBuilder.RegisterType<EfUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<BaseService>().As<IService>().InstancePerLifetimeScope().AsInterfacesProxy();
            //containerBuilder.RegisterType<BaseDataRepository>().As<IBaseDataRepository>().InstancePerLifetimeScope().AsInterfacesProxy();
            //containerBuilder.RegisterAspectCore();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
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
            }
        }
    }
}
