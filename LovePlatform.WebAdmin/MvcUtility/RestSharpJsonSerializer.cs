using Newtonsoft.Json;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LovePlatform.WebAdmin.MvcUtility
{
    public class RestSharpJsonSerializer : ISerializer
    {
        public RestSharpJsonSerializer()
        {
            ContentType = "application/json";
        }

        public string ContentType { get; set; }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
