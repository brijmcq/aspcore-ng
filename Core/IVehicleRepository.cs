using System.Threading.Tasks;
using asp_ng.Models;

namespace asp_ng.Core
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id,bool includeRelated =true);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
    }
}