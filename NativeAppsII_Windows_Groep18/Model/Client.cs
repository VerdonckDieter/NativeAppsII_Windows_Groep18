using NativeAppsII_Windows_Groep18.DataModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NativeAppsII_Windows_Groep18.Model
{
    public class Client : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _firstname;
        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        private string _lastname;
        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

        private DateTime _birthdate;
        public DateTime Birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                _birthdate = value;
                OnPropertyChanged("Birthdate");
            }
        }
        public ObservableCollection<TravelList> TravelLists { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
