using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace asp_ng.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        [Required]
        public Contact Contact { get; set; }
        public ICollection<int> Features { get; set; }
        public VehicleViewModel()
        {
            Features = new Collection<int>();
        }

    }
}