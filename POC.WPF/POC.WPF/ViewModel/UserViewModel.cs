using POC.WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace POC.WPF.ViewModel
{
    public class UserViewModel
    {
        private IList<User> _users;

        public UserViewModel()
        {
            _users = new List<User> {
                new User{UserId = 1,FirstName="Raj",LastName="Beniwal",City="Delhi",State="DEL",Country="INDIA"},
                new User{UserId=2,FirstName="Mark",LastName="henry",City="New York", State="NY", Country="USA"},
                new User{UserId=3,FirstName="Mahesh",LastName="Chand",City="Philadelphia", State="PHL", Country="USA"},
                new User{UserId=4,FirstName="Vikash",LastName="Nanda",City="Noida", State="UP", Country="INDIA"},
                new User{UserId=5,FirstName="Harsh",LastName="Kumar",City="Ghaziabad", State="UP", Country="INDIA"},
                new User{UserId=6,FirstName="Reetesh",LastName="Tomar",City="Mumbai", State="MP", Country="INDIA"},
                new User{UserId=7,FirstName="Deven",LastName="Verma",City="Palwal", State="HP", Country="INDIA"},
                new User{UserId=8,FirstName="Ravi",LastName="Taneja",City="Delhi", State="DEL", Country="INDIA"}
            };
        }

        public IList<User> Users { get { return _users; } set { _users = value; } }

        private ICommand _updateCommand;
        public ICommand UpdateCommand {
            get {
                if (_updateCommand == null)
                {
                    _updateCommand = new Updater();
                }
                return _updateCommand;
            }
            set {
                _updateCommand = UpdateCommand;
            }
        }
    }

    public class Updater : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        { }
    }
}
