using System.Collections.Generic;
using System.Threading.Tasks;
using asp_ng.Data;
using asp_ng.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_ng.Controllers
{
    public class MakesController : Controller
    {
        private readonly VegaDbContext context;
        public MakesController(VegaDbContext context)
        {
            this.context = context;

        }
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<Make>> GetMakes()
        {
            return await context.Makes.Include( m=> m.Models).ToListAsync();
        }
    }
}