using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAPI
{
    public sealed class WebAPIOutput<TValue> : OutputBase
    {
        private TValue _resultValue;

        /// <summary>
        /// ResultValue
        /// </summary>
        public TValue ResultValue
        {
            get { return _resultValue; }
            set { _resultValue = value; }
        }

        /// <summary>
        ///无参构造函数 
        /// </summary>
        public WebAPIOutput()
        {

        }

        private WebAPIOutput(bool isSuccess, string message, TValue resultValue)
        {
            IsSuccess = isSuccess;
            Message = message ?? string.Empty;
            ResultValue = resultValue;
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="resultValue">返回值</param>
        /// <returns></returns>
        public static WebAPIOutput<TValue> Success(TValue resultValue)
        {
            return new WebAPIOutput<TValue>(true, string.Empty, resultValue);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="resultValue">返回值</param>
        /// <param name="message">message</param>
        /// <returns></returns>
        public static WebAPIOutput<TValue> Success(TValue resultValue, string message)
        {
            return new WebAPIOutput<TValue>(true, message, resultValue);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">message</param>
        /// <returns></returns>
        public new static WebAPIOutput<TValue> Fail(string message)
        {
            return new WebAPIOutput<TValue>(false, message, default(TValue));
        }
    }
}
