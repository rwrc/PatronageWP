using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace PatronageWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPlacePage : Page
    {
       // Place place;
        AddPlacePageViewModel PlaceViewModel;
        
        public AddPlacePage()
        {
            this.InitializeComponent();
            PlaceViewModel = new AddPlacePageViewModel();
            this.DataContext = PlaceViewModel;
            
            this.NavigationCacheMode = NavigationCacheMode.Required;
          /*  place = new Place()
            {
                Name="WIZUT",
                Address="Żołnierska 49",
                Latitude=160,
                Longitude=14.6,
                HasWifi=true
            };
            this.DataContext = place;*/
            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        async private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Geolocator _geolocator = new Geolocator(); 
            Geoposition pos = await _geolocator.GetGeopositionAsync();

            PlaceViewModel.Place.Latitude = pos.Coordinate.Point.Position.Latitude;
            PlaceViewModel.Place.Longitude = pos.Coordinate.Point.Position.Longitude; 
        }


    }
}
