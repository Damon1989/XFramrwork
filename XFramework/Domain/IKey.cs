namespace XFramework.Domain
{
    /// <summary>
    /// 标识
    /// </summary>
    /// <typeparam name="Tkey">标识类型</typeparam>
    public interface IKey<out Tkey>
    {
        /// <summary>
        /// 标识
        /// </summary>
        Tkey Id { get; }
    }
}