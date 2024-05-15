using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public partial class Person
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public string? Gender { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public virtual ICollection<GamesCompetitor> GamesCompetitors { get; } = new List<GamesCompetitor>();
    }
}
