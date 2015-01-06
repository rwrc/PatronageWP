using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using PatronageWP.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace PatronageWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPlacePage : Page
    {
       // Place place;

        public AddPlacePage()
        {
            this.InitializeComponent();
            
            
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
            var placeViewModel = new AddPlacePageViewModel();
            this.DataContext = placeViewModel;

            this.NavigationCacheMode = NavigationCacheMode.Required;
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }



    }
}
