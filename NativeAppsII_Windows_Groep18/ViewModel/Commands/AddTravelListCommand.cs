using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NativeAppsII_Windows_Groep18.ViewModel.Commands
{
    public class AddTravelListCommand : ICommand
    {
        #region Properties
        public event EventHandler CanExecuteChanged;

        public TravelListViewModel ViewModel { get; set; }
        #endregion

        #region Constructor
        public AddTravelListCommand(TravelListViewModel vm)
        {
            this.ViewModel = vm;
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => AddTravelList(parameter);

        private async void AddTravelList(object t) => await ViewModel.AddTravelList(); 
        #endregion
    }
}
