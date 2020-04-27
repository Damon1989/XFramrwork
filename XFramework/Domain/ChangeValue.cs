namespace XFramework.Domain
{
    using System.Text;

    /// <summary>
    ///     变更值
    /// </summary>
    public class ChangeValue
    {
        /// <summary>
        ///     初始化变更值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="description"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public ChangeValue(string propertyName, string description, string oldValue, string newValue)
        {
            this.PropertyName = propertyName;
            this.Description = description;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        /// <summary>
        ///     描述
        /// </summary>
        public string Description { get; }

        /// <summary>
        ///     新值
        /// </summary>
        public string NewValue { get; }

        /// <summary>
        ///     旧值
        /// </summary>
        public string OldValue { get; }

        /// <summary>
        ///     属性名
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        ///     输出变更信息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat($"{this.PropertyName}({this.Description})");
            result.AppendFormat($"旧值：{this.OldValue},新值：{this.NewValue}");
            return result.ToString();
        }
    }
}