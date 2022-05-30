using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp4
{
    public class Reg : Helper
    {
        private RelayCommand _register;
        private string _fname;
        private string _sname;
        private string _lname;
        private string _login;
        private string _password;
        private RelayCommand _back;
        private ObservableCollection<User> _user = new(Service.db.Users);
        public RelayCommand Register => _register ??
                                   (_register = new RelayCommand((x) =>
                                   {
                                       if (FName == null || SName == null || LName == null || Login == null || Password == null)
                                       {
                                           MessageBox.Show("Заполните полностью все поля регистрации");
                                           return;
                                       }

                                       if (FName != null && SName != null && LName != null && Login != null && Password != null)
                                       {
                                           var userscol = UsersCol.FirstOrDefault(x => x.Login == Login);

                                           {
                                               User user = new User()
                                               {
                                                   FirstName = FName,
                                                   SecondName = SName,
                                                   LastName = LName,
                                                   Login = Login,
                                                   Password = Password,

                                               };
                                               Service.db.Users.Add(user);
                                               Service.db.SaveChanges();
                                               OnPropertyChanged();
                                               MessageBox.Show("Регистрация прошла успешно!");
                                               Service.frame.Navigate(new AuthorizationPage());
                                           }
                                       }
                                   }));
        public RelayCommand Back => _back ??
                            (_back = new RelayCommand((x) =>
                            {
                                Service.frame.Navigate(new AuthorizationPage());
                            }));
        public ObservableCollection<User> UsersCol
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        public string FName
        {
            get => _fname;
            set
            {
                _fname = value;
                OnPropertyChanged();
            }
        }

        public string SName
        {
            get => _sname;
            set
            {
                _sname = value;
                OnPropertyChanged();
            }
        }

        public string LName
        {
            get => _lname;
            set
            {
                _lname = value;
                OnPropertyChanged();
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }


    }
}
