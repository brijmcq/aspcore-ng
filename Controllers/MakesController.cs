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
    public class MakesController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public MakesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeViewModel>> GetMakes()
        {
            var makes =  await context.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>,List<MakeViewModel>>(makes);
        }

    }
}