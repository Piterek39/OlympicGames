using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public partial class PersonRegion
    {
        public int? PersonId { get; set; }

        public int? RegionId { get; set; }

        public virtual Person? Person { get; set; }

        public virtual NocRegion? Region { get; set; }
    }
}
