using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace asp_ng.ViewModels
{
    public class MakeViewModel
    {
       
        public MakeViewModel()
        {
            Models = new Collection<ModelViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ModelViewModel> Models { get; set; }

    }
}