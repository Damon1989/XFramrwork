using Microsoft.Extensions.DependencyInjection;

namespace XFramework.Dependency
{
    /// <summary>
    /// 依赖引导器
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// 服务集合
        /// </summary>
        private readonly IServiceCollection _services;
        /// <summary>
        /// 依赖配置
        /// </summary>
        private readonly IConfig[] _configs;

    }
}