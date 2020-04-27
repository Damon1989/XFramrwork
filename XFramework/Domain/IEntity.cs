namespace XFramework.Domain
{
    /// <summary>
    /// 实体
    /// </summary>
    public interface IEntity:IDomainObject
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Init();
    }

    /// <summary>
    /// 实体
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public interface IEntity<out Tkey> : IKey<Tkey>, IEntity
    {

    }

    /// <summary>
    /// 实体
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="Tkey">标识类型</typeparam>
    public interface IEntity<in TEntity, out Tkey> : ICompareChange<TEntity>, IEntity<Tkey>
        where TEntity : IEntity
    {

    }
}