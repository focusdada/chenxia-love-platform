using AutoMapper;
using LovePlatform.Common.Enum;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.Service.AutoMapperConfig.Profiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<BloodPressure, BloodPressureDto>()
                .ForMember(d => d.IsDoctorInput, opt => { opt.MapFrom(s => s.DataSource > (int)DataSourceTypeEnum.WeixinInput); })
                .ForMember(d => d.MeasureResultIsNormal, opt => { opt.MapFrom(s => s.IsNormal); });
        }
    }
}
