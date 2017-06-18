using System.Threading.Tasks;
using asp_ng.Models;
using System.Collections.Generic;

namespace asp_ng.Core
{
    public interface IVehicleRepository
    {
        Task<T> GetVehicle(int id,bool includeRelated =true);
        void Add(T vehicle);
        void Remove(T vehicle);
        Task<IEnumerable<T>> GetVehicles(VehicleQuery filter);
    }
}