//using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public partial class Event
    {
        public int Id { get; set; }

        public int? SportId { get; set; }

        public string? EventName { get; set; }

        public virtual Sport? Sport { get; set; }
    }
}
