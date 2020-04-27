﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace XFramework.Dependency
{
    /// <summary>
    /// 容器
    /// </summary>
    public interface IContainer:IDisposable
    {
        /// <summary>
        /// 创建集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        List<T> CreateList<T>(string name = null);
        /// <summary>
        /// 创建集合
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        object CreateList(Type type, string name = null);
        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        T Create<T>(string name = null);
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        object Create(Type type, string name = null);
        /// <summary>
        /// 作用域开始
        /// </summary>
        /// <returns></returns>
        IScope BeginScope();
        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="configs">依赖配置</param>
        void Register(params IConfig[] configs);
        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务类型</param>
        /// <param name="configs">依赖配置</param>
        /// <returns></returns>
        IServiceProvider Register(IServiceCollection services, params IConfig[] configs);

    }
}