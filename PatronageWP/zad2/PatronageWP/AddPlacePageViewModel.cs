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

namespace PatronageWP
{
    class AddPlacePageViewModel:ObservableObject
    {
        Place _place;
        //public ObservableCollection<Place> PlacesList { get; set; }
        PlaceService _placesList{ get; set; }

        public AddPlacePageViewModel()
        {
            
            _placesList = new PlaceService();
            //PlacesList = new ObservableCollection<Place>();
            _place = new Place();
            _place.PropertyChanged += PlaceChange;
        }

        public void PlaceChange(Object sender, PropertyChangedEventArgs e)
        {
            this.RaisePropertyChanged("Place");
            AddPlace.RaiseCanExecuteChanged(); //Not working

        }

        public Place Place
        {
            get
            {
                return _place;
            }

            set
            {
                _place = value;
            }
        }

        void AddExecute()
        {

            //PlacesList.Add(_place);
            _placesList.AddPlace(_place);
            _place = new Place();
            (new MessageDialog("Dodano poprawnie")).ShowAsync();
        }

        bool CanAdd()
        {
            return true;
          //  return ((_place.Name!=null) && (_place.Name.Length) > 0);

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
                _place.Address = "";
                _place.HasWifi = false;
                _place.Name = "";

            }));
            md.Commands.Add(new UICommand("Nie"));
            md.ShowAsync();
            
         

        }

        public RelayCommand AddPlace { get { return new RelayCommand(AddExecute, CanAdd); } }
        public ICommand ClearPlace { get { return new RelayCommand(ClearExecute, CanClear); } }


    }
}
