using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Users
{
    public class UserModel : BindableBase
    {
        private string _firstName;
        private string _lastName;
        private string _fullName;

        public int UserId { get; set; }

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); OnPropertyChanged("FullName"); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); OnPropertyChanged("FullName"); }
        }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = _firstName + " " + _lastName; }
        }
    }
}
