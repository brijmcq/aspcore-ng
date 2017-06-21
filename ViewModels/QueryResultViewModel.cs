using asp_ng.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_ng.ViewModels
{
    public class QueryResultViewModel<T>
    {

        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
