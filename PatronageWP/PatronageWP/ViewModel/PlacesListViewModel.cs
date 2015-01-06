using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroMvvm;
using PatronageWP.Model;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls;
using PatronageWP.View;

namespace PatronageWP.ViewModel
{
    class PlacesListViewModel : ObservableObject
    {
        PlaceService _placesList = PlaceService.Instance;
        private RelayCommand _addCommand;
        private readonly INavigationService _navigationService;

        public PlacesListViewModel()
        {
            _navigationService = NavigationService.Instance;
            _placesList.PropertyChanged +=_placesList_PropertyChanged;          
        }

        private void _placesList_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.RaisePropertyChanged("Places");
        }

        public IReadOnlyCollection<Place> Places
        {
            get { return _placesList.GetPlaces(); }
        }

        void AddExecute()
        {
            _navigationService.Navigate(typeof(AddPlacePage));
        }

        bool CanAdd()
        {
            return true;
        }

        bool CanClear()
        {
            return true;
        }

        public RelayCommand AddPlace
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(AddExecute, CanAdd)); }
        }

      //  System.Device.Location.GeoCoordinate

    }
}
