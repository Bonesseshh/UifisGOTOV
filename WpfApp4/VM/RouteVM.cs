using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp4
{
    public class RouteVM : Helper
    {
        
        private RelayCommand _find;
        private ObservableCollection<Transport> _findroute = new(Service.db.Transports.Include(x => x.IdRouteNavigation).Where(x => x.Number == 10000));
        private string _numberroute;
        private ObservableCollection<TypeTransport> _typetr = new(Service.db.TypeTransports);
        private TypeTransport _selectedtype;
        public RelayCommand Find => _find ??
            (_find = new RelayCommand((x) =>
           {
               var SelectedTp = SelectedType;
               if (SelectedTp == null)
               {
                   MessageBox.Show("Выберете тип транспорта");
                   return;
               }
               if (SelectedTp != null)
               {
                  FindRoute = new ObservableCollection<Transport>(Service.db.Transports.Include(x => x.IdRouteNavigation).Where(x => x.Number == Convert.ToInt32(NumberRoute) && x.IdType == SelectedTp.IdTransport));
               }
           }));
        public TypeTransport SelectedType
        {
            get => _selectedtype;
            set
            { 
                _selectedtype = value; 
                OnPropertyChanged();   
            }
        }
        public ObservableCollection<TypeTransport> TypeTr
        {
            get => _typetr;
            set
            {
                _typetr = value;
                OnPropertyChanged();
            }
        }
            public ObservableCollection<Transport> FindRoute
        {
            get => _findroute;
            set
            {
                _findroute = value;               
                OnPropertyChanged();
            }
        }
        public string NumberRoute
        {
            get => _numberroute;
            set
            {
                _numberroute = value;
                OnPropertyChanged();
            }
        }
    }
}
