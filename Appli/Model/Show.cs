using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public partial class Show
    {
        public Guid ShowId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; } 

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }

        public string Picture { get; set; }

        public List<Performance> Performances { get; set; }

    }
}
