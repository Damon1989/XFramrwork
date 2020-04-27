namespace XFramework.Dependency
{
    using System;

    /// <summary>
    ///     作用域
    /// </summary>
    public interface IScope : IDisposable
    {
        /// <summary>
        ///     创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Create<T>();

        /// <summary>
        ///     创建对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Create(Type type);
    }
}