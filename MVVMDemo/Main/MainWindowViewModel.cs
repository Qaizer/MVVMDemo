using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo
{
    public class MainWindowViewModel : BindableBase
    {
        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel { get { return _currentViewModel; } set { SetProperty(ref _currentViewModel, value); } }
        private UserViewModel _userViewModel = new UserViewModel();

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
