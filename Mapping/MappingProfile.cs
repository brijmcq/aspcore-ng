using asp_ng.Models;
using asp_ng.ViewModels;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;

namespace asp_ng.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Make,MakeViewModel>();
            CreateMap<Model,ModelViewModel>();
            CreateMap<Feature, FeatureViewModel>();
            CreateMap<Vehicle,VehicleViewModel>()
            .ForMember( x=> x.Contact, opt=> opt.MapFrom( y=> new Contact{Name = y.ContactName
            ,Email = y.ContactEmail, Phone = y.ContactPhone }))
            .ForMember( x=> x.Features, opt=> opt.MapFrom( y=> y.Features.Select(z=> z.FeatureId)));



            CreateMap<VehicleViewModel,Vehicle>()
            .ForMember(x=> x.Id, opt=> opt.Ignore())
            .ForMember(x=> x.ContactName, opt => opt.MapFrom( y=> y.Contact.Name))
            .ForMember(x=> x.ContactPhone, opt => opt.MapFrom( y=> y.Contact.Phone))
            .ForMember(x=> x.ContactEmail, opt => opt.MapFrom( y=> y.Contact.Email))
            .ForMember(x=> x.Features, opt => opt.Ignore())
            .AfterMap( (src,target)=>{
              var removedFeatures = target.Features.Where( x=> src.Features.Contains(x.FeatureId));
                foreach( var item in removedFeatures){
                    target.Features.Remove(item);
                }
              var addedFeatures = src.Features.Where( id => !target.Features.Any( f=> f.FeatureId == id))
              .Select( x=> new VehicleFeature{FeatureId = x});
                foreach(var item in addedFeatures){
                    target.Features.Add(item);
                }
            }); 



        }
    }
}