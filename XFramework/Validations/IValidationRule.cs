using System.ComponentModel.DataAnnotations;

namespace XFramework.Validations
{
    /// <summary>
    /// 验证规则
    /// </summary>
    public interface IValidationRule
    {
        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        ValidationResult Validate();
    }
}