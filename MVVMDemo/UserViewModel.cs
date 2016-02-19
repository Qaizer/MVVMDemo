using Repositories;
using Repositories.Divisions;
using Repositories.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo
{
    public class UserViewModel : BindableBase
    {

        private ObservableCollection<User> _userList;

        private DivisionRepository _divisionRepository = new DivisionRepository();

        private ObservableCollection<Division> _divisionList;

        public ObservableCollection<Division> DivisionList { get { return _divisionList; } set { SetProperty(ref _divisionList, value); } }

        private UserRepository _userRepository = new UserRepository();

        public ObservableCollection<User> UserList { get { return _userList; } set { SetProperty(ref _userList, value); } }

        public UserViewModel()
        {

        }

        public async void PopulateList()
        {

            //var tempUserList = (List<User>)_userRepository.GetAll();
            //UserList = new ObservableCollection<User>(tempUserList);
            var tempDivisionList = await _divisionRepository.GetAll();
            DivisionList = new ObservableCollection<Division>(tempDivisionList);

        }
    }
}
