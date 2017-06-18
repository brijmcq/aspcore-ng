using asp_ng.Core;
using asp_ng.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_ng.Data
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext context;
        public VehicleRepository(VegaDbContext context)
        {
            this.context = context;
        }
        public async Task<Vehicle> GetVehicle(int id,bool includeRelated = true)
        {
            if (!includeRelated)
            {
                return await context.Vehicles.FindAsync(id);
            }
            return await context.Vehicles
         .Include(x => x.Features)
             .ThenInclude(y => y.Feature)
         .Include(x => x.Model)
             .ThenInclude(x => x.Make)
         .SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }
        public void Remove(Vehicle vehicle)
        {
            context.Remove(vehicle);
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles(Filter filter)
        {
            var query =  context.Vehicles
                .Include(x => x.Model)
                    .ThenInclude(x => x.Make)
                .Include(x => x.Features)
                    .ThenInclude(x => x.Feature)
                .AsQueryable();
            if (filter.MakeId.HasValue)
            {
                query = query.Where(x => x.Model.MakeId == filter.MakeId.Value);
            }
            return await query.ToListAsync() ;
        }


    }
}
