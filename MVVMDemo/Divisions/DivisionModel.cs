using MVVMDemo.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Divisions
{
    public class DivisionModel : BindableBase
    {
        private string _name;

        public int DivisionId { get; set; }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public List<UserModel> Users { get; set; }
    }
}
