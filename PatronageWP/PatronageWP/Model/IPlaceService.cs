using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronageWP
{
    interface IPlaceService
    {
        void AddPlace(Place p);
        IReadOnlyCollection<Place> GetPlaces();
    }
}
