using asp_ng.Core;
using asp_ng.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_ng.Data
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly VegaDbContext context;

        public PhotoRepository(VegaDbContext context)
        {
            this.context = context;
        }

        public async Task DeletePhotoAsync(int photoId)
        {
            var photo = new Photo { Id = photoId };
            context.Entry(photo).State = EntityState.Deleted;
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Photo>> GetPhotos(int vehicleId)
        {

            return await context.Photos
                .Where(x => x.VehicleId == vehicleId).AsNoTracking()
                .ToListAsync();
        }
    }
}
