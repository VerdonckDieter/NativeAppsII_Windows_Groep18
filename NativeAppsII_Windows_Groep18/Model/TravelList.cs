using NativeAppsII_Windows_Groep18.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NativeAppsII_Windows_Groep18.DataModel
{
    public class TravelList : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        private Itinerary _itinerary;
        public Itinerary Itinerary
        {
            get
            {
                return _itinerary;
            }
            set
            {
                _itinerary = value;
                OnPropertyChanged("Itinerary");
            }
        }

        private int _progress;
        public int Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                _progress = value;
                OnPropertyChanged("Progress");
            }
        }

        public ObservableCollection<Item> Items { get; set; }
        public Dictionary<string, List<Item>> ItemsGrouped { get; set; }
        public ObservableCollection<Task> Tasks { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateProgress()
        {
            double count = Items.Count(i => i.Added == true);
            Progress = (int)(count / Items.Count() * 100);
        }
    }
}
