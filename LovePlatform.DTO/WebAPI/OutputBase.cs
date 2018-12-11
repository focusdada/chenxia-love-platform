using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.DTO.WebAPI
{
    /// <summary>
    /// WebAPIOutput基类
    /// </summary>
    public class OutputBase
    {
        private bool _isSuccess;
        /// <summary>
        /// IsSuccess
        /// </summary>
        public bool IsSuccess
        {
            get { return _isSuccess; }
            set { _isSuccess = value; }
        }

        private string _message;
        /// <summary>
        /// Message
        /// </summary>
        public string Message
        {
            get { return _message ?? string.Empty; }
            set { _message = value; }
        }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public OutputBase()
        {
        }

        private OutputBase(bool isSuccess, string message)
        {
            _isSuccess = isSuccess;
            _message = message ?? string.Empty;
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="message">message</param>
        /// <returns></returns>
        public static OutputBase Success(string message)
        {
            return new OutputBase(true, message);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">message</param> 
        /// <returns></returns>
        public static OutputBase Fail(string message)
        {
            return new OutputBase(false, message);
        }
    }
}
