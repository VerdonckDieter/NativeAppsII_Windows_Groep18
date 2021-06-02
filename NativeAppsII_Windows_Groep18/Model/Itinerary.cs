using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeAppsII_Windows_Groep18.Model
{
    public class Itinerary : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private double _startLatitude;
        public double StartLatitude
        {
            get
            {
                return _startLatitude;
            }
            set
            {
                _startLatitude = value;
                OnPropertyChanged("StartLatitude");
            }
        }

        private double _startLongitude;
        public double StartLongitude
        {
            get
            {
                return _startLongitude;
            }
            set
            {
                _startLongitude = value;
                OnPropertyChanged("StartLongitude");
            }
        }

        private double _endLatitude;
        public double EndLatitude
        {
            get
            {
                return _endLatitude;
            }
            set
            {
                _endLatitude = value;
                OnPropertyChanged("EndLatitude");
            }
        }

        private double _endLongitude;
        public double EndLongitude
        {
            get
            {
                return _endLongitude;
            }
            set
            {
                _endLongitude = value;
                OnPropertyChanged("EndLongitude");
            }
        }

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
