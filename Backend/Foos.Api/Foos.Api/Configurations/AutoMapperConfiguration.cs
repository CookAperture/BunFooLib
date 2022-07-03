using BunFooLib.Api.Shared.Dto.Foos.Foo;
using Foos.Api.Database.Contracts.Entities;
using AutoMapper;
using BunFooLib.Api.Shared.Dto.Foos.FooCategory;
using BunFooLib.Api.Shared.Dto.Foos.Measurement;
using BunFooLib.Api.Shared.Dto.Foos.RecommendedAmountPerDay;

namespace Foos.Api.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<FooEntity, FooDto>().ReverseMap();
            CreateMap<FooEntity, FooAddDto>().ReverseMap();
            
            CreateMap<FooCategoryEntity, FooCategoryDto>().ReverseMap();
            CreateMap<FooCategoryEntity, FooCategoryAddDto>().ReverseMap();
            
            CreateMap<MeasurementEntity, MeasurementDto>().ReverseMap();
            CreateMap<MeasurementEntity, MeasurementAddDto>().ReverseMap();
            
            CreateMap<RecommendedAmountPerDayEntity, RecommendedAmountPerDayDto>().ReverseMap();
            CreateMap<RecommendedAmountPerDayEntity, RecommendedAmountPerDayAddDto>().ReverseMap();
        }
    }
}
