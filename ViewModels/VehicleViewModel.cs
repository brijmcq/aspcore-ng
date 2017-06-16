using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace asp_ng.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
    
        public KeyValuePairViewModel Model { get; set; }
        public KeyValuePairViewModel Make { get; set; }
        public bool IsRegistered { get; set; }
        public Contact Contact { get; set; }
        public DateTime LastUpdate{ get; set; }
        public ICollection<FeatureViewModel> Features { get; set; }
        public VehicleViewModel()
        {
            Features = new Collection<FeatureViewModel>();
        }
    }
}