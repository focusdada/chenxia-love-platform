using LovePlatform.Domain.Models;
using LovePlatform.DTO.Common;
using LovePlatform.DTO.WebAPI;
using LovePlatform.DTO.WebAPI.Input;
using LovePlatform.DTO.WebAPI.Output;
using LovePlatform.H5.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LovePlatform.H5
{
    public class LovePlatformApi
    {
        private string _baseUrl;

        public LovePlatformApi(string baseUrl)
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

        #region 患者
        /// <summary>
        /// 获取患者
        /// </summary>
        /// <param name="openId">微信OpenId</param>
        /// <returns></returns>
        public async Task<DictDto> GetPatientByOpenId(string openId)
        {
            var request = new RestRequest();
            request.Resource = "/api/Patient/OpenId/{openId}";
            request.AddParameter("openId", openId, ParameterType.UrlSegment);

            var response = await ExecuteAsync<WebAPIOutput<DictDto>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return response.ResultValue;
            }
            return null;
        }

        /// <summary>
        /// 获取患者
        /// </summary>
        /// <param name="idNo">身份证号</param>
        /// <returns></returns>
        public async Task<GetPatientByIdNoOutput> GetPatientByIdNo(string idNo)
        {
            var request = new RestRequest();
            request.Resource = "/api/Patient/IdNo/{idNo}";
            request.AddParameter("idNo", idNo, ParameterType.UrlSegment);

            var response = await ExecuteAsync<WebAPIOutput<GetPatientByIdNoOutput>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return response.ResultValue;
            }
            return null;
        }

        /// <summary>
        /// 患者微信绑定
        /// </summary>
        /// <param name="input">绑定输入</param>
        /// <returns></returns>
        public async Task<OutputBase> PatientBindWeixin(BindWeixinInput input)
        {
            var request = new RestRequest();
            request.Method = Method.PUT;
            request.Resource = "/api/Patient/BindWeixin";
            request.AddParameter("IdNo", input.IdNo, ParameterType.QueryString);
            request.AddParameter("OpenId", input.OpenId, ParameterType.QueryString);

            return await ExecuteAsync<OutputBase>(request);
        }

        /// <summary>
        /// 获取患者详情
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <returns></returns>
        public async Task<PatientDto> GetPatientDetail(long patientId)
        {
            var request = new RestRequest();
            request.Resource = "/api/Patient/{patientId}";
            request.AddParameter("patientId", patientId, ParameterType.UrlSegment);

            var response = await ExecuteAsync<WebAPIOutput<PatientDto>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return response.ResultValue;
            }
            return null;
        }
        #endregion

        #region 用户
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="wexinOpenId">微信OpenID</param>
        /// <returns></returns>
        public async Task<User> GetUserByOpenId(string wexinOpenId)
        {
            var request = new RestRequest()
            {
                Resource = "/api/User/{wexinOpenId}"
            };
            request.AddParameter("wexinOpenId", wexinOpenId, ParameterType.UrlSegment);

            var response = await ExecuteAsync<WebAPIOutput<User>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return response.ResultValue;
            }
            return null;
        }

        public async Task<User> GetUser(int userId)
        {
            var request = new RestRequest()
            {
                Resource = "/api/User/GetUser/{userId}"
            };
            request.AddParameter("userId", userId, ParameterType.UrlSegment);

            var response = await ExecuteAsync<WebAPIOutput<User>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return response.ResultValue;
            }
            return null;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<OutputBase> AddUser(User user)
        {
            var request = new RestRequest()
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonSerializer(),
                Method = Method.POST,
                Resource = "/api/User/AddUser"
            };
            request.AddBody(user);

           return await ExecuteAsync<OutputBase>(request);
        }


        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<OutputBase> UpdateUser(User user)
        {
            var request = new RestRequest()
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonSerializer(),
                Method = Method.PUT,
                Resource = "/api/User/UpdateUser"
            };
            request.AddBody(user);

            return await ExecuteAsync<OutputBase>(request);
        }


        /// <summary>
        /// 更新用户头像
        /// </summary>
        /// <param name="userAvatarDto">用户头像</param>
        /// <returns></returns>
        public async Task<OutputBase> UpdateUserAvatar(AddUserAvatarDto userAvatarDto)
        {
            var request = new RestRequest()
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonSerializer(),
                Method = Method.PUT,
                Resource = "/api/User/UpdateUserAvatar"
            };
            request.AddBody(userAvatarDto);
            var response = await ExecuteAsync<OutputBase>(request);
            return response;
        }
        #endregion

        #region 诊断
        /// <summary>
        /// 获取诊断
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Diagnose> GetDiagnose(int userId)
        {
            var request = new RestRequest()
            {
                Resource = "/api/Diagnose/{userId}"
            };
            request.AddParameter("userId", userId, ParameterType.UrlSegment);

            var response = await ExecuteAsync<WebAPIOutput<Diagnose>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return response.ResultValue;
            }
            return null;
        }

        /// <summary>
        /// 添加诊断
        /// </summary>
        /// <param name="diagnose"></param>
        /// <returns></returns>
        public async Task<OutputBase> AddDiagnose(Diagnose diagnose)
        {
            var request = new RestRequest()
            {
                Resource = "/api/Diagnose",
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonSerializer(),
                Method = Method.POST
            };
            request.AddBody(diagnose);

            return await ExecuteAsync<OutputBase>(request);
        }

        /// <summary>
        /// 更新诊断
        /// </summary>
        /// <param name="diagnose"></param>
        /// <returns></returns>
        public async Task<OutputBase> UpdateDiagnose(Diagnose diagnose)
        {
            var request = new RestRequest()
            {
                Resource = "/api/Diagnose/UpdateDiagnose",
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonSerializer(),
                Method = Method.PUT
            };
            request.AddBody(diagnose);

            return await ExecuteAsync<OutputBase>(request);
        }
        #endregion

        #region 治疗
        /// <summary>
        /// 获取治疗
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Treat> GetTreat(int id)
        {
            var request = new RestRequest()
            {
                Resource = "/api/Treat/{id}"
            };
            request.AddParameter("id", id, ParameterType.UrlSegment);

            var response = await ExecuteAsync<WebAPIOutput<Treat>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return response.ResultValue;
            }
            return null;
        }

        /// <summary>
        /// 获取治疗列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Treat>> GetTreatList(int userId)
        {
            var request = new RestRequest()
            {
                Resource = "/api/Treat/GetList/{userId}"
            };
            request.AddParameter("userId", userId, ParameterType.UrlSegment);

            var response = await ExecuteAsync<WebAPIOutput<List<Treat>>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return response.ResultValue;
            }
            return null;
        }

        /// <summary>
        /// 添加治疗
        /// </summary>
        /// <param name="treat"></param>
        /// <returns></returns>
        public async Task<WebAPIOutput<int>> AddTreat(AddTreatDto treatDto)
        {
            var request = new RestRequest()
            {
                Resource = "/api/Treat",
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonSerializer(),
                Method = Method.POST
            };
            request.AddBody(treatDto);

            return await ExecuteAsync<WebAPIOutput<int>>(request);
        }

        /// <summary>
        /// 更新治疗
        /// </summary>
        /// <param name="treat"></param>
        /// <returns></returns>
        public async Task<OutputBase> UpdateTreat(Treat treat)
        {
            var request = new RestRequest()
            {
                Resource = "/api/Treat/UpdateTreat",
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonSerializer(),
                Method = Method.PUT
            };
            request.AddBody(treat);

            return await ExecuteAsync<OutputBase>(request);
        }
        #endregion

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

        public async Task<OutputBase> DeleteTreatImage(int treatId)
        {
            var request = new RestRequest()
            {
                Resource = "/api/TreatImage",
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonSerializer(),
                Method = Method.DELETE
            };
            request.AddBody(treatId);

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

        /// <summary>
        /// 获取最新top数量血压列表
        /// </summary>
        /// <param name="patientId">患者Id</param>
        /// <param name="topNumber">top数量</param>
        /// <returns></returns>
        public async Task<List<BloodPressureDto>> GetBloodPressureList(long patientId, int topNumber)
        {
            var request = new RestRequest();
            request.Resource = "/api/BloodPressure/{patientId}/{topNumber}";
            request.AddParameter("patientId", patientId, ParameterType.UrlSegment);
            request.AddParameter("topNumber", topNumber, ParameterType.UrlSegment);

            var response = await ExecuteAsync<WebAPIOutput<List<BloodPressureDto>>>(request);
            if (response.IsSuccess && response.ResultValue != null)
            {
                return response.ResultValue;
            }
            return null;
        }

        /// <summary>
        /// 新增血压
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OutputBase> AddBloodPressure(AddBloodPressureInput input)
        {
            var request = new RestRequest();
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new RestSharpJsonSerializer();
            request.Method = Method.POST;
            request.Resource = "/api/BloodPressure";
            request.AddBody(input);

            return await ExecuteAsync<OutputBase>(request);
        }
    }
}
