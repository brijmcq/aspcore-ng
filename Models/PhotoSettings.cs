using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace asp_ng.Models
{
    public class PhotoSettings
    {
        public int MaxFileSize { get; set; }
        public string[] AcceptedFileTypes { get; set; }
        public bool IsSupported(string fileName)
        {
            return AcceptedFileTypes.Any(x => x == Path.GetExtension(fileName).ToLower());


        }

    }
}
