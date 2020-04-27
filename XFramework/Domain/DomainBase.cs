namespace XFramework.Domain
{
    using System.Collections.Generic;
    using System.Text;
    using XFramework.Validations;

    public abstract class DomainBase<T>:IDomainObject,ICompareChange<T> where T:IDomainObject
    {
        /// <summary>
        /// 描述
        /// </summary>
        private StringBuilder _description;
        /// <summary>
        /// 验证规则集合
        /// </summary>
        private readonly List<IValidationRule> _rules;
        /// <summary>
        /// 验证处理器
        /// </summary>
        private IValidationHandler _handler;
        /// <summary>
        /// 变更值集合
        /// </summary>
        private ChangeValueCollection _changeValues;

        /// <summary>
        /// 初始化领域层顶级基类
        /// </summary>
        protected DomainBase()
        {
            _rules = new List<IValidationRule>();
            _handler = new ThrowHandler();
        }

        /// <summary>
        /// 设置验证处理器
        /// </summary>
        /// <param name="handler"></param>
        public void SetValidationHandler(IValidationHandler handler)
        {
            if (handler==null)
            {
                return;
            }

            _handler = handler;
        }

        /// <summary>
        /// 添加验证规则列表
        /// </summary>
        /// <param name="rules">验证规则列表</param>
        public void AddValidationRules(IEnumerable<IValidationRule> rules)
        {
            if (rules==null)
            {
                return;
            }

            foreach (var rule in rules)
            {
                AddValidationRule(rule);
            }
        }

        /// <summary>
        /// 添加验证规则
        /// </summary>
        /// <param name="rule"></param>
        public void AddValidationRule(IValidationRule rule)
        {
            if (rule==null)
            {
                return;
            }

            _rules.Add(rule);
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public virtual ValidationResultCollection Validate()
        {
            var result = GetValidationResults();
            HandleValidationResults(result);
            return result;
        }

        /// <summary>
        /// 获取验证结果
        /// </summary>
        /// <returns></returns>
        private ValidationResultCollection GetValidationResults()
        {
            var result = DataAnnotationValidation.Validate(this);
            Validate(result);
            foreach (var rule in _rules)
            {
                result.Add(rule.Validate());
            }

            return result;
        }

        /// <summary>
        /// 验证并添加到验证结果集合
        /// </summary>
        /// <param name="results"></param>
        protected virtual void Validate(ValidationResultCollection results)
        {

        }

        /// <summary>
        /// 处理验证结果
        /// </summary>
        /// <param name="results"></param>
        private void HandleValidationResults(ValidationResultCollection results)
        {
            if (results.IsValid)
            {
                return;
            }

            _handler.Handle(results);
        }

        protected void AddChange<TDomainObject>(
            IEnumerable<ICompareChange<IDomainObject>> oldObjects,
            IEnumerable<IDomainObject> newObjects)
            where TDomainObject : IDomainObject
        {
            if (Equals(oldObjects,null))
            {
                return;
            }

            if (Equals(newObjects,null))
            {
                return;
            }
        }


    }
}