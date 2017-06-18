using System;
using System.Threading.Tasks;
using asp_ng.Models;
using asp_ng.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using asp_ng.Core;
using System.Collections;
using System.Collections.Generic;

namespace asp_ng.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repo;
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IMapper mapper,IVehicleRepository repo,IUnitOfWork unitOfWork)
        {
            
            this.mapper = mapper;
            this.repo = repo;
            this.unitOfWork = unitOfWork;

        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleViewModel vm)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var vehicle = mapper.Map<SaveVehicleViewModel, Vehicle>(vm);
            vehicle.LastUpdate = DateTime.Now;
            repo.Add(vehicle);
            await unitOfWork.CompleteAsync();


            vehicle = await repo.GetVehicle(vehicle.Id);



            var result = mapper.Map<Vehicle,VehicleViewModel>(vehicle);
            return Ok(result);
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id,[FromBody] SaveVehicleViewModel vm)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var vehicle = await repo.GetVehicle(id);

            if (vehicle==null)
                return NotFound();
    
            mapper.Map<SaveVehicleViewModel, Vehicle>(vm,vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await unitOfWork.CompleteAsync();
            vehicle = await repo.GetVehicle(vehicle.Id);
            var result = mapper.Map<Vehicle,VehicleViewModel>(vehicle);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id){
            var vehicle = await repo.GetVehicle(id, includeRelated:false);
            if(vehicle==null)
            return NotFound();
                
            repo.Remove(vehicle);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id){
            var vehicle = await repo.GetVehicle(id);
            if (vehicle==null)
            return NotFound();

            var vm = mapper.Map<Vehicle,VehicleViewModel>(vehicle);

            return Ok(vm); 
        }
      
        public async Task<IEnumerable<VehicleViewModel>> GetVehicles(VehicleQueryViewModel vm)
        {
            var filter = mapper.Map<VehicleQueryViewModel, VehicleQuery>(vm);

            var vehicles = await repo.GetVehicles(filter);
           
           var result = mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleViewModel>>(vehicles);

            return result;
        }

    }
}
