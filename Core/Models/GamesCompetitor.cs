//using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public partial class GamesCompetitor
    {
        public int Id { get; set; }

        public int? GamesId { get; set; }

        public int? PersonId { get; set; }

        public int? Age { get; set; }

        public virtual Game? Games { get; set; }

        public virtual Person? Person { get; set; }
    }
}
