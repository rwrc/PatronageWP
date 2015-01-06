using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using MicroMvvm;

namespace PatronageWP
{
    class PlaceService : ObservableObject,IPlaceService
    {
        ObservableCollection<Place> _places;

       private static PlaceService _instance;


       public static PlaceService Instance
       {
          get { return _instance ?? (_instance = new PlaceService()); }
       }


        private PlaceService()
        {
            _places = new ObservableCollection<Place>();
        }


        public void AddPlace(Place p)
        {
            _places.Add(p);
            RaisePropertyChanged("GetPlaces");
        }

        public IReadOnlyCollection<Place> GetPlaces()
        {
            return new ReadOnlyCollection<Place>(_places); 
        }
    }
}
