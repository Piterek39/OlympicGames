using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public partial class GamesCity
    {
        public int? GamesId { get; set; }

        public int? CityId { get; set; }

        public virtual City? City { get; set; }

        public virtual Game? Games { get; set; }
    }
}
