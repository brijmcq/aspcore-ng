using asp_ng.Core;
using asp_ng.Extensions;
using asp_ng.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery queryObj)
        {
            var result = new QueryResult<Vehicle>();
            var query = context.Vehicles
                .Include(x => x.Model)
                    .ThenInclude(x => x.Make)
                .Include(x => x.Features)
                    .ThenInclude(x => x.Feature)
                .AsQueryable();
            if (queryObj.MakeId.HasValue)
            {
                query = query.Where(x => x.Model.MakeId == queryObj.MakeId.Value);
            }
            if (queryObj.ModelId.HasValue)
            {
                query = query.Where(x => x.ModelId == queryObj.ModelId.Value);
            }


            var columnsMap = new Dictionary<string, Expression<Func<Vehicle, object>>>()
            {
                ["make"] = x => x.Model.Make.Name,
                ["model"] = x => x.Model.Name,
                ["contactName"] = x => x.ContactName
            };
            query = query.ApplyOrdering(queryObj, columnsMap);
            result.TotalItems = await query.CountAsync();
            query = query.ApplyPaging(queryObj);
           
            result.Items =  await query.ToListAsync();
            return result;
        }

     

    }
}
