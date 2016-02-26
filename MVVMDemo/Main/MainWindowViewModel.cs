using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.Users;

namespace MVVMDemo.Main
{
    public class MainWindowViewModel : BindableBase
    {
        private BindableBase _currentViewModel;
        private UserViewModel _userViewModel = new UserViewModel();


        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        

        public RelayCommand NavCommand { get; private set; }


        public MainWindowViewModel()
        {


            NavCommand = new RelayCommand(ChangeView);

        }

        public void ChangeView(object view)
        {
            //kan byggas till switch vid många views
            if(view.Equals("User"))
            {
                CurrentViewModel = _userViewModel;
            }


        }

    }
}
