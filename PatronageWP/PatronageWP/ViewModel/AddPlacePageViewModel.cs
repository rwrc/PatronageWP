using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MicroMvvm;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;

namespace PatronageWP
{
    class AddPlacePageViewModel:ObservableObject
    {
        Place _place;
        RelayCommand _addCommand;
        RelayCommand _clearCommand;
        Geolocator _geolocator;

        PlaceService _placesList { get; set; }
        public Place Place
        {
            get
            {
                return _place;
            }
        }

        async void GetPos()
        {
            Geoposition pos = await _geolocator.GetGeopositionAsync();
            Place.Latitude = pos.Coordinate.Point.Position.Latitude;
            Place.Longitude = pos.Coordinate.Point.Position.Longitude; 
        }

        void NewPlace()
        {
            _place = new Place();
            GetPos();
            _place.PropertyChanged += PlaceChange;
            RaisePropertyChanged("Place");
        }

        public AddPlacePageViewModel()
        {
            _placesList = new PlaceService();
            _geolocator = new Geolocator();
            NewPlace();
        }

        public void PlaceChange(Object sender, PropertyChangedEventArgs e)
        {
            this.RaisePropertyChanged("Place");
            AddPlace.RaiseCanExecuteChanged(); 
        }

        void AddExecute()
        {
            _placesList.AddPlace(_place);
            NewPlace();
            (new MessageDialog("Dodano poprawnie "+_placesList.GetPlaces().Count+" lokalizację")).ShowAsync();
        }

        bool CanAdd()
        {
            return ((_place.Name!=null) && (_place.Name.Length) > 0);
        }

        bool CanClear()
        {
            return true;
        }   

        void ClearExecute()
        {
            MessageDialog md = new MessageDialog("Czy chcesz usunąć?");
            md.Commands.Add(new UICommand("Tak", x =>
            {
                NewPlace();
            }));
            md.Commands.Add(new UICommand("Nie"));
            md.ShowAsync();
        }

        public RelayCommand AddPlace { 
            get 
            {
                if (_addCommand == null) _addCommand = new RelayCommand(AddExecute, CanAdd);
                return _addCommand;
            } 
        }
        public RelayCommand ClearPlace
        { 
            get 
            {
                if (_clearCommand == null) _clearCommand = new RelayCommand(ClearExecute, CanClear);
                return _clearCommand;
            } 
        }
    }
}
