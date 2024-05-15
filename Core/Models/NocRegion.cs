using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public partial class NocRegion
    {
        public int Id { get; set; }

        public string? Noc { get; set; }

        public string? RegionName { get; set; }
    }
}
