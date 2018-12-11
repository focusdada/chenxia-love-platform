using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.Service.AutoMapperConfig
{
    public class DtoMapping
    {
        public static void WebApiConfigure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<Profiles.CommonProfile>();
                cfg.AddProfile<Profiles.WebApiProfile>();
            });
            ValidateConfigure();
        }

        public static void WebAdminConfigure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<Profiles.CommonProfile>();
                cfg.AddProfile<Profiles.WebAdminProfile>();
            });
            ValidateConfigure();
        }

        public static void H5Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<Profiles.CommonProfile>();
                cfg.AddProfile<Profiles.H5Profile>();
            });
            ValidateConfigure();
        }

        /// <summary>
        /// 验证配置
        /// </summary>
        private static void ValidateConfigure()
        {
            try
            {
                Mapper.Configuration.AssertConfigurationIsValid();
            }
            catch (AutoMapperConfigurationException)
            {
            }
        }
    }
}
