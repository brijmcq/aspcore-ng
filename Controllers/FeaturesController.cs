using System.Collections.Generic;
using System.Threading.Tasks;
using asp_ng.Data;
using asp_ng.Models;
using asp_ng.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_ng.Controllers
{
    public class FeaturesController:Controller
    {
         private readonly VegaDbContext context;
    private readonly IMapper mapper;
    public FeaturesController(VegaDbContext context, IMapper mapper)
    {
      this.mapper = mapper;
      this.context = context;
    }
    [HttpGet("/api/features")]
    public async Task<IEnumerable<FeatureViewModel>> GetFeatures(){
        var features = await context.Features.ToListAsync();
         return mapper.Map<List<Feature>, List<FeatureViewModel>>(features); 
    }
    }
}