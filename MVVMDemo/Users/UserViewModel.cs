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

namespace MVVMDemo
{
    public class UserViewModel : BindableBase
    {

        private ObservableCollection<User> _userList;
        private ObservableCollection<DivisionModel> _divisionList;
        private IUserRepository _userRepository = new UserRepository();
        private IDivisionRepository _divisionRepository = new DivisionRepository();


        public ObservableCollection<User> UserList
        {
            get { return _userList; }
            set { SetProperty(ref _userList, value); }
        }

        public ObservableCollection<DivisionModel> DivisionList
        {
            get { return _divisionList; }
            set { SetProperty(ref _divisionList, value); }
        }

        public async void PopulateList()
        {
            //TODO: Lägg till users i divisions med For-loop
            var divisions = await _divisionRepository.GetAll();
            DivisionList = new ObservableCollection<DivisionModel>(divisions.Select(x => x.MapToModel()));

            foreach (var div in DivisionList)
            {
                var users = await _userRepository.GetAll(div.DivisionId);
                div.Users = (List<UserModel>)users.Select(x => x.MapToModel());
                
            }
        }
    }
}
