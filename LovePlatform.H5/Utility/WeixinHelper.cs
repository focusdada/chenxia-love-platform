using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LovePlatform.H5.Utility
{
    public class WeixinHelper
    {
        private string _weixinAppId;
        private string _weixinAppSecret;

        public WeixinHelper(string weixinAppId, string weixinAppSecret)
        {
            _weixinAppId = weixinAppId;
            _weixinAppSecret = weixinAppSecret;
        }

        /// <summary>
        /// 获取微信OpenId
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<string> GetOpenId(string code)
        {
            var request = new RestRequest();
            request.Resource = "sns/oauth2/access_token";
            request.AddParameter("appid", _weixinAppId, ParameterType.QueryString);
            request.AddParameter("secret", _weixinAppSecret, ParameterType.QueryString);
            request.AddParameter("code", code, ParameterType.QueryString);
            request.AddParameter("grant_type", "authorization_code", ParameterType.QueryString);

            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.weixin.qq.com/");
            var taskCompletionSource = new TaskCompletionSource<WeixinUserInfo>();
            client.ExecuteAsync(request, (response) =>
            {
                if (response.ErrorException != null)
                {
                    //const string message = "Error retrieving response.  Check inner details for more info.";
                    //LogHelper.WriteError(message, response.ErrorException);
                    throw response.ErrorException;
                }
                taskCompletionSource.SetResult(JsonConvert.DeserializeObject<WeixinUserInfo>(response.Content));
            });

            return (await taskCompletionSource.Task).openid;
        }
    }

    public class WeixinUserInfo
    {
        public string access_token { get; set; }

        public int expires_in { get; set; }

        public string refresh_token { get; set; }

        public string openid { get; set; }

        public string scope { get; set; }
    }
}
