using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace asp_ng.ViewModels
{
    public class MakeViewModel:KeyValuePairViewModel
    {
       
        public MakeViewModel()
        {
            Models = new Collection<KeyValuePairViewModel>();
        }
        public ICollection<KeyValuePairViewModel> Models { get; set; }

    }
}