namespace XFramework.Dependency
{
    using System;

    using Autofac;

    /// <summary>
    /// 作用域
    /// </summary>
    public class Scope : IScope
    {
        /// <summary>
        /// autofac作用域
        /// </summary>
        private readonly ILifetimeScope _scope;
        /// <summary>
        /// 初始化作用域
        /// </summary>
        /// <param name="scope"></param>
        public Scope(ILifetimeScope scope)
        {
            this._scope = scope;
        }
        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Create<T>()
        {
            return this._scope.Resolve<T>();
        }
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object Create(Type type)
        {
            return this._scope.Resolve(type);
        }
        /// <summary>
        /// 释放对象
        /// </summary>
        public void Dispose()
        {
            this._scope.Dispose();
        }
    }
}