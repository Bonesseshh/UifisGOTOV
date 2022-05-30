using System;
using System.Collections.Generic;

namespace WpfApp4
{
    public partial class User
    {
        public User()
        {
            Transports = new HashSet<Transport>();
        }

        public int IdUser { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Transport> Transports { get; set; }
    }
}
