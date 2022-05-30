using System;
using System.Collections.Generic;

namespace WpfApp4
{
    public partial class Transport
    {
        public int IdTransports { get; set; }
        public int Number { get; set; }
        public int IdUser { get; set; }
        public int IdRoute { get; set; }
        public int IdType { get; set; }

        public virtual Route IdRouteNavigation { get; set; } = null!;
        public virtual TypeTransport IdTypeNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
