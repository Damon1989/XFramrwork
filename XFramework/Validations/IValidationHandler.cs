namespace XFramework.Validations
{
    /// <summary>
    /// 验证处理器
    /// </summary>
    public interface IValidationHandler
    {
        /// <summary>
        /// 处理验证错误
        /// </summary>
        /// <param name="results"></param>
        void Handle(ValidationResultCollection results);
    }
}