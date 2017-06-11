using asp_ng.Models;
using asp_ng.ViewModels;
using AutoMapper;

namespace asp_ng.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Make,MakeViewModel>().ReverseMap();
            CreateMap<Model,ModelViewModel>().ReverseMap();
        }
    }
}