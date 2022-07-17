using AutoMapper;
using RealTimeMVCapp.Data.Entities;
using RealTimeMVCapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeMVCapp.MappingProfile
{
    public class RealTimeMappingProfile : Profile
    {
       public RealTimeMappingProfile()
        {
            CreateMap<Material, MaterialViewModel>()
                .ForMember(o => o.mId, e => e.MapFrom(es => es.materialId)).ReverseMap();

            CreateMap<MaterialItems, MaterialItemViewModel>().ReverseMap();
        }
    }
}
