using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class MainWindowVM : Helper
    {
        public MainWindowVM()
        {
            Service.frame.Navigate(new AuthorizationPage());
        }
        private RelayCommand _profile;
        private RelayCommand _route;
        public RelayCommand Profile => _profile ??
                                             (_profile = new RelayCommand((x) =>
                                             {
                                                 if (Service.user.Login != null)
                                                 {
                                                     Service.frame.Navigate(new ProfilePage());
                                                 }
                                             }));
        public RelayCommand Route => _route ??
            (_route = new RelayCommand((x) =>
            {
                if (Service.user.Login != null)
                {
                    Service.frame.Navigate(new RoutePage());
                }
            }));
    }
}
