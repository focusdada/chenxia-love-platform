using AutoMapper;
using LovePlatform.Common;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.WebAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace LovePlatform.Service.AutoMapperConfig.Profiles
{
    public class WebApiProfile : Profile
    {
        public WebApiProfile()
        {
            CreateMap<Weight, WeightDto>()
                .ForMember(d => d.MeasureTime, opt => opt.MapFrom(c => c.MeasureTime.ToString("yyyy-MM-dd HH:mm:ss")));

            CreateMap<Patient, PatientBaseDto>()
                .ForMember(d => d.PatientFace, opt => opt.MapFrom(c => string.IsNullOrEmpty(c.PatientFace) ? string.Empty : (CommConstant.OssUrl + c.PatientFace)));

            CreateMap<Patient, PatientDto>()
                .ForMember(d => d.PatientFace, opt => opt.MapFrom(c => string.IsNullOrEmpty(c.PatientFace) ? string.Empty : (CommConstant.OssUrl + c.PatientFace)))
                .ForMember(d => d.HasWeightData, opt => { opt.Ignore(); });
        }
    }
}
