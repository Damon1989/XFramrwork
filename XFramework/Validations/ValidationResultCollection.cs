using System.Collections.Generic;

namespace XFramework.Validations
{
    using System.Collections;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// 验证结果集合
    /// </summary>
    public class ValidationResultCollection:IEnumerable<ValidationResult>
    {
        /// <summary>
        /// 验证结果
        /// </summary>
        private readonly List<ValidationResult> _results;
        /// <summary>
        /// 初始化验证结果集合
        /// </summary>
        public ValidationResultCollection():this("")
        {
            
        }

        /// <summary>
        /// 初始化验证结果集合
        /// </summary>
        /// <param name="result"></param>
        public ValidationResultCollection(string result)
        {
            this._results = new List<ValidationResult>();
            if (string.IsNullOrWhiteSpace(result))
            {
                return;
            }

            this._results.Add(new ValidationResult(result));
        }

        /// <summary>
        /// 成功验证结果集合
        /// </summary>
        public static readonly ValidationResultCollection Success = new ValidationResultCollection();

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid => this._results.Count == 0;

        /// <summary>
        /// 验证结果个数
        /// </summary>
        public int Count => this._results.Count;
        /// <summary>
        /// 添加验证结果
        /// </summary>
        /// <param name="result"></param>
        public void Add(ValidationResult result)
        {
            if (_results==null)
            {
                return;
            }

            _results.Add(result);
        }

        /// <summary>
        /// 添加验证结果集合
        /// </summary>
        /// <param name="results"></param>
        public void AddList(IEnumerable<ValidationResult> results)
        {
            if (_results==null)
            {
                return;
            }

            foreach (var result in results)
            {
                Add(result);
            }
        }

        /// <summary>
        /// 获取迭代器
        /// </summary>
        /// <returns></returns>
        IEnumerator<ValidationResult> IEnumerable<ValidationResult>.GetEnumerator() { 
            return _results.GetEnumerator();
        }

        /// <summary>
        /// 获取迭代器
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        /// <summary>
        /// 输出验证消息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (IsValid)
            {
                return string.Empty;
            }

            return _results.First().ErrorMessage;
        }
    }
}