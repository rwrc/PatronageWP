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
using Windows.Phone.UI.Input;
using PatronageWP.Model;
using PatronageWP.View;

namespace PatronageWP.ViewModel
{
    class AddPlacePageViewModel:ObservableObject
    {
        private Place _place;
        private RelayCommand _addCommand;
        private RelayCommand _clearCommand;
        private Geolocator _geolocator;
        private NavigationService _navigationService;

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
            _navigationService = NavigationService.Instance;
            _placesList = PlaceService.Instance;
            _geolocator = new Geolocator();
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            NewPlace();
        }

        private void GoBack()
        {
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            _navigationService.GoBack();
           // _navigationService.Navigate(typeof(PlacesList));

        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            GoBack();
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
            GoBack();
            //(new MessageDialog("Dodano poprawnie "+_placesList.GetPlaces().Count+" lokalizację")).ShowAsync();
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
            GoBack();
            /*
            var md = new MessageDialog("Czy chcesz usunąć?");
            md.Commands.Add(new UICommand("Tak", x =>
            {
                NewPlace();
            }));
            md.Commands.Add(new UICommand("Nie"));
            md.ShowAsync();
             */
        }

        public RelayCommand AddPlace { 
            get { return _addCommand ?? (_addCommand = new RelayCommand(AddExecute, CanAdd)); }
        }
        public RelayCommand ClearPlace
        { 
            get { return _clearCommand ?? (_clearCommand = new RelayCommand(ClearExecute, CanClear)); }
        }
    }
}
