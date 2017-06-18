using asp_ng.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_ng.Models
{
    public class VehicleQuery:IQueryObject
    {
        public int? MakeId { get; set; }
        public int? ModelId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }

    }
}
