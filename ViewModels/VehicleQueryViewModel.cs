using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_ng.ViewModels
{
    public class VehicleQueryViewModel
    {
        public int? MakeId { get; set; }
        public int? ModelId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
