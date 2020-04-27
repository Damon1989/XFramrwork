using Microsoft.Extensions.DependencyInjection;

namespace XFramework.Dependency
{
    /// <summary>
    /// 依赖注册齐
    /// </summary>
    public class IDependencyRegister
    {
        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        void Register(IServiceCollection services);

    }
}