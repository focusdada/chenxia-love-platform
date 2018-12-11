using AutoMapper;
using LovePlatform.Common;
using LovePlatform.Common.Enum;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.H5;
using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.Service.AutoMapperConfig.Profiles
{
    public class H5Profile : Profile
    {
        public H5Profile()
        {
            CreateMap<User, LoginUserDto>()
                    .ForMember(x => x.Avatar, opt => opt.MapFrom(c => string.IsNullOrEmpty(c.Avatar) ? string.Empty : (CommConstant.OssUrl + c.Avatar)));
            CreateMap<Diagnose, DiagnoseDto>()
                    .ForMember(x => x.DiseasesType, opt => opt.MapFrom(c => EnumHelper.GetDescription<DiseasesTypeEnum>((DiseasesTypeEnum)c.DiseasesType)));
        }
    }
}
