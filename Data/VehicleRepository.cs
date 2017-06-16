using asp_ng.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_ng.Data
{
    public class VehicleRepository
    {
        private readonly VegaDbContext context;
        public VehicleRepository(VegaDbContext context)
        {
            this.context = context;
        }
        public async Task<Vehicle> GetVehicle(int id)
        {
            return await context.Vehicles
         .Include(x => x.Features)
             .ThenInclude(y => y.Feature)
         .Include(x => x.Model)
             .ThenInclude(x => x.Make)
         .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
