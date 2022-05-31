using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class Profile : Helper
    {
        private RelayCommand _report;
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string NumberPhone { get; set; }

        public Profile()
        {
            FirstName = Service.user.FirstName;
            SecondName = Service.user.SecondName;
            LastName = Service.user.LastName;
        }
    }
}
