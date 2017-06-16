using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_ng.Data;
using asp_ng.Models;
using asp_ng.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_ng.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        public VehiclesController(IMapper mapper, VegaDbContext context)
        {
            this.context = context;
            this.mapper = mapper;

        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleViewModel vm)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var vehicle = mapper.Map<VehicleViewModel, Vehicle>(vm);
            vehicle.LastUpdate = DateTime.Now;
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();


            vehicle = await context.Vehicles
              .Include(x => x.Features)
                  .ThenInclude(y => y.Feature)
              .Include(x => x.Model)
                  .ThenInclude(x => x.Make)
              .SingleOrDefaultAsync(x => x.Id == vehicle.Id);



            var result = mapper.Map<Vehicle,VehicleViewModel>(vehicle);
            return Ok(result);
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id,[FromBody] VehicleViewModel vm)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var vehicle = await context.Vehicles
            .Include(x => x.Features)
                .ThenInclude(y => y.Feature)
            .Include(x => x.Model)
                .ThenInclude(x => x.Make)
            .SingleOrDefaultAsync(x => x.Id == id);

            if (vehicle==null)
                return NotFound();
    
            mapper.Map<VehicleViewModel, Vehicle>(vm,vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await context.SaveChangesAsync();
            var result = mapper.Map<Vehicle,VehicleViewModel>(vehicle);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id){
            var vehicle = await context.Vehicles.FindAsync(id);
            if(vehicle==null)
            return NotFound();
            
            context.Remove(vehicle);
            await context.SaveChangesAsync();

            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id){
            var vehicle = await context.Vehicles
            .Include(x=> x.Features)
                .ThenInclude(y=> y.Feature)
            .Include(x=> x.Model)
                .ThenInclude(x=> x.Make)
            .SingleOrDefaultAsync(x=> x.Id==id);
            

            if(vehicle==null)
            return NotFound();

            var vm = mapper.Map<Vehicle,VehicleViewModel>(vehicle);

            return Ok(vm); 
        }

        
    }
}
