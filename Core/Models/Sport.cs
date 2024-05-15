using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public partial class Sport
    {
        public int Id { get; set; }

        public string? SportName { get; set; }

        public virtual ICollection<Event> Events { get; } = new List<Event>();
    }
}
