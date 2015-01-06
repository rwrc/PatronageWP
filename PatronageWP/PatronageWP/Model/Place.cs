using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroMvvm;

namespace PatronageWP
{
    class Place:ObservableObject//INotifyPropertyChanged
    {
        private string _name;
        private string _adress;
        private double _latitude;
        private double _longitude;
        private bool _hasWifi;



        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                this.RaisePropertyChanged("Name");
                //NotifyPropertyChanged("Name");
            }
        }
        public string Adress
        {
            get { return _adress; }
            set
            {
                _adress = value;
                RaisePropertyChanged("Adress");
            }
        }
        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                RaisePropertyChanged("Latitude");
            }
        }
        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                RaisePropertyChanged("Longitude");
            }
        }

        public string Position
        {
            get { return Latitude.ToString() + ',' + Longitude.ToString(); }
        }
        public bool HasWifi 
        { 
            get{return _hasWifi;}
            set
            {
                _hasWifi = value;
                RaisePropertyChanged("HasWifi");
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return string.Format("{0}, {1}",Name,Adress);
        }

/*
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        */
    }
}
