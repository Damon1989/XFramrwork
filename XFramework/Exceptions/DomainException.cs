﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using XFramework.Event;
using XFramework.Infrastructure;

namespace XFramework.Exceptions
{
    public class ErrorCodeDictionary
    {
        private static readonly Dictionary<object, string> _errorcodeDic = new Dictionary<object, string>();

        public static string GetErrorMessage(object errorcode, params object[] args)
        {
            var errorMessage = _errorcodeDic.TryGetValue(errorcode, string.Empty);
            if (string.IsNullOrEmpty(errorMessage))
            {
                var errorCodeFieldInfo = errorcode.GetType().GetField(errorcode.ToString());
                if (errorCodeFieldInfo != null)
                {
                    errorMessage = errorCodeFieldInfo.GetCustomAttribute<DescriptionAttribute>()?.Description;
                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        errorMessage = errorcode.ToString();
                    }
                }
            }

            if (args != null && args.Length > 0)
            {
                return string.Format(errorMessage, args);
            }

            return errorMessage;
        }

        public static void AddErrorCodeMessage(IDictionary<object, string> dictionary)
        {
            dictionary.ForEach(p =>
            {
                if (_errorcodeDic.ContainsKey(p.Key))
                {
                    throw new Exception($"ErrorCode dictionary has already had the key {p.Key}");
                }

                _errorcodeDic.Add(p.Key, p.Value);
            });
        }
    }

    [Serializable]
    public class DomainException : Exception
    {
        public IDomainExceptionEvent DomainExceptionEvent { get; protected set; }
        public object ErrorCode { get; protected set; }
        internal string ErrorCodeType { get; set; }

        public DomainException()
        {
        }

        public DomainException(IDomainExceptionEvent domainExceptionEvent)
            : this(domainExceptionEvent.ErrorCode, domainExceptionEvent.ToString())
        {
            DomainExceptionEvent = domainExceptionEvent;
        }

        public DomainException(object errorCode, string message = null)
            : base(message ?? ErrorCodeDictionary.GetErrorMessage(errorCode))
        {
            ErrorCode = errorCode;
        }

        public DomainException(object errorCode, object[] args)
        : base(ErrorCodeDictionary.GetErrorMessage(errorCode, args))
        {
            ErrorCode = errorCode;
        }

        public DomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ErrorCodeType = (string)info.GetValue(nameof(ErrorCodeType), typeof(string));
            if (ErrorCodeType != null)
            {
                ErrorCode = info.GetValue(nameof(ErrorCode), Type.GetType(ErrorCodeType));
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(ErrorCode), ErrorCode);
            info.AddValue(nameof(ErrorCodeType), ErrorCode?.GetType().GetFullNameWithAssembly());
            base.GetObjectData(info, context);
        }
    }
}