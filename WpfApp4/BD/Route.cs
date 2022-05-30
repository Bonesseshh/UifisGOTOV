using System;
using System.Collections.Generic;

namespace WpfApp4
{
    public partial class Route
    {
        public Route()
        {
            Transports = new HashSet<Transport>();
        }

        public int IdRoute { get; set; }
        public string Route1 { get; set; } = null!;

        public virtual ICollection<Transport> Transports { get; set; }
    }
}
