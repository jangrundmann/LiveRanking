using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.JModels
{
    public class RaceExport
    {
        public string Method { get; set; }
        public string Format { get; set; }
        public string Status { get; set; }
        public string ExportCreated { get; set; }

        public List<Result> Data { get; set; }

    }
}
