//using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public partial class Game
    {
        public int Id { get; set; }

        public int? GamesYear { get; set; }

        public string? GamesName { get; set; }

        public string? Season { get; set; }

        public virtual ICollection<GamesCompetitor> GamesCompetitors { get; } = new List<GamesCompetitor>();
    }
}
