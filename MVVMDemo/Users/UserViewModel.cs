using Repositories;
using Repositories.Divisions;
using Repositories.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MVVMDemo.Extensions;
using MVVMDemo.Divisions;
using MVVMDemo.Users;

namespace MVVMDemo.Users
{
    public class UserViewModel : BindableBase
    {

        private ObservableCollection<UserModel> _userList;
        private ObservableCollection<DivisionModel> _divisionList;
        private IUserRepository _userRepository = new UserRepository();
        private IDivisionRepository _divisionRepository = new DivisionRepository();
        private DivisionModel _selectedDivision;
        private UserModel _selectedUser;
         
        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set { SetProperty(ref _selectedUser, value); }
        }

        public ObservableCollection<UserModel> UserList
        {
            get { return _userList; }
            set { SetProperty(ref _userList, value); }
        }

        public ObservableCollection<DivisionModel> DivisionList
        {
            get { return _divisionList; }
            set { SetProperty(ref _divisionList, value);  }
        }

        public DivisionModel SelectedDivision
        {
            get { return _selectedDivision; }
            set { SetProperty(ref _selectedDivision, value); UpdateUserList(); }
        }

        public async void PopulateList()
        {
            //TODO: Lägg till users i divisions med For-loop
            var divisions = await _divisionRepository.GetAll();
            DivisionList = new ObservableCollection<DivisionModel>(divisions.Select(x => x.MapToModel()));

            foreach (var div in DivisionList)
            {
                var users = await _userRepository.GetAll(div.DivisionId);
                div.Users = users.Select(x => x.MapToModel()).ToList();
            }
        }

        public void UpdateUserList()
        {
            UserList = new ObservableCollection<UserModel>(SelectedDivision.Users);
        }
    }
}
