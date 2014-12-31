using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

namespace PatronageWP
{
    class PlaceService : IPlaceService
    {
        List<Place> _places;
        public PlaceService()
        {
            _places = new List<Place>();

        }

        public void AddPlace(Place p)
        {
            _places.Add(p);
        }

        public List<Place> GetPlaces()
        {
            //return new ReadOnlyCollection<Place>(_places);
            return _places;
        }
    }
}
