using System.Collections.Generic;
using System.Text;

namespace XFramework.Domain
{
    /// <summary>
    /// 变更值集合
    /// </summary>
    public class ChangeValueCollection:List<ChangeValue>
    {
        public void Add(string propertyName, string description, string oldValue, string newValue)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return;
            }

            Add(new ChangeValue(propertyName, description, oldValue, newValue));
        }

        /// <summary>
        /// 输出变更信息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var item in this)
            {
                result.Append($"{item},");
            }

            return result.ToString();
        }
    }
}