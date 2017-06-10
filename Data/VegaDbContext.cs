using asp_ng.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_ng.Data
{
    public class VegaDbContext:DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options)
        :base(options)
        {
            
        }
        public DbSet<Make> Makes { get; set; }
    }
}