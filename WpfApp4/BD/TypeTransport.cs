using System;
using System.Collections.Generic;

namespace WpfApp4
{
    public partial class TypeTransport
    {
        public TypeTransport()
        {
            Transports = new HashSet<Transport>();
        }

        public int IdTransport { get; set; }
        public string NameTransport { get; set; } = null!;

        public virtual ICollection<Transport> Transports { get; set; }
    }
}
