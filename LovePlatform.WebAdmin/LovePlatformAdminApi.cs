using LovePlatform.Domain.Models;
using LovePlatform.DTO.Common;
using LovePlatform.DTO.WebAPI;
using LovePlatform.DTO.WebAPI.Input;
using LovePlatform.DTO.WebAPI.Output;
using LovePlatform.WebAdmin.MvcUtility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LovePlatform.WebAdmin
{
    public class LovePlatformAdminApi
    {
        private string _baseUrl;

        public LovePlatformAdminApi(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(_baseUrl);
            //client.Authenticator = new HttpBasicAuthenticator(UserName, Password);

            var taskCompletionSource = new TaskCompletionSource<T>();
            client.ExecuteAsync<T>(request, (response) =>
            {
                if (response.ErrorException != null)
                {
                    const string message = "Error retrieving response.  Check inner details for more info.";
                    //LogHelper.WriteError(message, response.ErrorException);
                    throw response.ErrorException;
                }
                taskCompletionSource.SetResult(response.Data);
            });

            return await taskCompletionSource.Task;
        }

        #region 治疗图片
        /// <summary>
        /// 添加治疗图片
        /// </summary>
        /// <param name="treatImage">资料图片</param>
        /// <returns></returns>
        public async Task<OutputBase> AddTreatImage(TreatImage treatImage)
        {
            var request = new RestRequest()
            {
                Resource = "/api/TreatImage",
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonSerializer(),
                Method = Method.POST
            };
            request.AddBody(treatImage);

            return await ExecuteAsync<OutputBase>(request);
        }

        public async Task<List<TreatImage>> GetTreatImageList(int treatId)
        {
            var request = new RestRequest()
            {
                Resource = "/api/TreatImage/GetList/{treatId}"
            };
            request.AddParameter("treatId", treatId, ParameterType.UrlSegment);

            var response = await ExecuteAsync<WebAPIOutput<List<TreatImage>>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return response.ResultValue;
            }
            return null;
        }
        #endregion

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<WebAPIOutput<string>> UploadImage(UploadImageInput input)
        {
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new RestSharpJsonSerializer();
            request.Method = Method.POST;
            request.Resource = "/api/Oss/UploadImage";
            request.AddBody(input);

            return await ExecuteAsync<WebAPIOutput<string>>(request);
        }
    }
}
