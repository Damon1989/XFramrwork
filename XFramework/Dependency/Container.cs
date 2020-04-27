namespace XFramework.Dependency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Autofac;
    using Autofac.Extensions.DependencyInjection;

    using Microsoft.Extensions.DependencyInjection;

    using XFramework.Helpers;

    /// <summary>
    ///     Autofac对象容器
    /// </summary>
    public class Container : IContainer
    {
        private Autofac.IContainer _container;

        /// <summary>
        ///     作用域开始
        /// </summary>
        /// <returns></returns>
        public IScope BeginScope()
        {
            return new Scope(this._container.BeginLifetimeScope());
        }

        /// <summary>
        ///     创建对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Create<T>(string name = null)
        {
            return (T)this.Create(typeof(T), name);
        }

        /// <summary>
        ///     创建对象
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public object Create(Type type, string name = null)
        {
            return Web.HttpContext?.RequestServices != null
                       ? this.GetServiceFromHttpContext(type, name)
                       : this.GetService(type, name);
        }

        /// <summary>
        ///     创建容器生成器
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前执行的操作</param>
        /// <param name="configs">依赖配置</param>
        /// <returns></returns>
        public ContainerBuilder CreateBuilder(
            IServiceCollection services,
            Action<ContainerBuilder> actionBefore,
            params IConfig[] configs)
        {
            var builder = new ContainerBuilder();
            actionBefore?.Invoke(builder);
            if (configs != null)
                foreach (var config in configs)
                    builder.RegisterModule(config);

            if (services == null)
            {
                services = new ServiceCollection();
                builder.AddSingleton(services);
            }

            builder.Populate(services);
            return builder;
        }

        /// <summary>
        ///     创建集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        public List<T> CreateList<T>(string name = null)
        {
            var result = this.CreateList(typeof(T), name);
            return result == null ? new List<T>() : ((IEnumerable<T>)result).ToList();
        }

        /// <summary>
        ///     创建集合
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        public object CreateList(Type type, string name = null)
        {
            var serviceType = typeof(IEnumerable<>).MakeGenericType(type);
            return this.Create(serviceType, name);
        }

        public void Dispose()
        {
            this._container.Dispose();
        }

        /// <summary>
        ///     注册依赖
        /// </summary>
        /// <param name="configs">依赖配置</param>
        public void Register(params IConfig[] configs)
        {
            return this.Register(null, null, configs);
        }

        /// <summary>
        ///     注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        /// <returns></returns>
        public IServiceProvider Register(IServiceCollection services, params IConfig[] configs)
        {
            return this.Register(services, null, configs);
        }

        /// <summary>
        ///     注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前操作</param>
        /// <param name="configs">依赖配置</param>
        /// <returns></returns>
        public IServiceProvider Register(
            IServiceCollection services,
            Action<ContainerBuilder> actionBefore,
            params IConfig[] configs)
        {
            var builder = this.CreateBuilder(services, actionBefore, configs);
            this._container = builder.Build();
            return new AutofacServiceProvider(this._container);
        }

        /// <summary>
        ///     获取服务
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private object GetService(Type type, string name)
        {
            if (name == null) return this._container.Resolve(type);

            return this._container.ResolveNamed(name, type);
        }

        /// <summary>
        ///     从HttpContext获取服务
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private object GetServiceFromHttpContext(Type type, string name)
        {
            var serviceProvider = Web.HttpContext.RequestServices;
            if (name == null) return serviceProvider.GetService(type);

            var context = serviceProvider.GetService<IComponentContext>();
            return context.ResolveNamed(name, type);
        }
    }
}