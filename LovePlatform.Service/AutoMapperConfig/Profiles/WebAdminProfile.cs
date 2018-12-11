using AutoMapper;
using LovePlatform.Common;
using LovePlatform.Common.Enum;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAdmin;
using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.Service.AutoMapperConfig.Profiles
{
    public class WebAdminProfile : Profile
    {
        public WebAdminProfile()
        {
            CreateMap<Patient, PatientViewDto>()
                .ForMember(d => d.Brithdate, opt => opt.MapFrom(c => c.Brithdate.ToString("yyyy-MM-dd")));

            CreateMap<Patient, PatientDetailViewDto>()
                .ForMember(d => d.Brithdate, opt => opt.MapFrom(c => c.Brithdate.ToString("yyyy-MM-dd")))
                .ForMember(d => d.UserStatusCss, opt => { opt.Ignore(); });

            CreateMap<Weight, AdminWeightDto>()
                .ForMember(d => d.MeasureTime, opt => opt.MapFrom(c => c.MeasureTime.ToString("MM-dd HH:mm").TrimStart('0')));

            CreateMap<Administrator, AdministratorDto>();
            
            CreateMap<Administrator, AdminLoginUserInfo>();

            CreateMap<User, UserDto>()
                .ForMember(d => d.Birthday, opt => opt.MapFrom(c => c.Birthday.ToShortDateFormatString()))
                .ForMember(d => d.Gender, opt => opt.MapFrom(c => EnumHelper.GetDescription<SexEnum>((SexEnum)c.Gender)))
                .ForMember(d => d.Type, opt => opt.MapFrom(c => EnumHelper.GetDescription<UserTypeEnum>((UserTypeEnum)c.Type)))
                .ForMember(d => d.State, opt => opt.MapFrom(c => EnumHelper.GetDescription<UserStateEnum>((UserStateEnum)c.State)));
        }
    }
}
