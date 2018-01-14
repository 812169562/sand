using Autofac;
using Microsoft.Extensions.DependencyModel;
using Sand.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace Sand.DI
{
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
        public static ContainerBuilder ContainerBuilder { get; set; }
        public static IContainer Container { get; set; }
        static DefaultIocConfig()
        {
            ContainerBuilder = new ContainerBuilder();
        }
    }
}
