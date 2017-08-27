using asp_ng.Core;
using asp_ng.Models;
using asp_ng.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace asp_ng.Controllers
{
    [Route("/api/vehicles/{vehicleId}/photos")]
    public class PhotosController:Controller
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IHostingEnvironment host;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly int MAX_PHOTO_FILESIZE = 5 * 1024 * 1024;
        private readonly string[] ACCEPTED_FILETYPES = new[] { ".jpg", ".jpeg", ".png" };


        public PhotosController(IHostingEnvironment host,
            IVehicleRepository vehicleRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
            ) 
        {
            this.host = host;
            this.unitOfWork = unitOfWork;
            this.vehicleRepository = vehicleRepository;
            this.mapper = mapper;
            Console.WriteLine("The environment www is" + host.WebRootPath);

        }
        public async Task<IActionResult> Upload(int vehicleId, IFormFile file) {
            var vehicle = await vehicleRepository.GetVehicle(vehicleId, includeRelated: false);

        
            #region validations
            if (vehicle == null)
            {
                return NotFound();
            }
            if (file == null || file.Length == 0)
            {
                return BadRequest("No photo");
            }
            // max file size is 5mb
            if(file.Length >MAX_PHOTO_FILESIZE)
            {
                return BadRequest("Maximum file size exceeded");
            }
            if(ACCEPTED_FILETYPES.Any(x => x == Path.GetExtension(file.FileName)))
            {
                return BadRequest("Invalid file type");
            }

            #endregion


            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }
            //todo: check for the extension of the file
            var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var newFilePath = Path.Combine(uploadsFolderPath, newFileName);
            using(var stream = new FileStream(newFilePath, FileMode.Create))
            {
               await  file.CopyToAsync(stream);
            }

            //todo: generate a thumbnail

            var photo = new Photo { FileName = newFileName };
            vehicle.Photos.Add(photo);
            await unitOfWork.CompleteAsync();


            return Ok(mapper.Map<Photo, PhotoViewModel>(photo));
        }
    }
}
