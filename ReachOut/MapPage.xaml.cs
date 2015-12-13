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
using Windows.Services.Maps;
using ReachOut.Managers;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using ReachOut.DataModel;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Windows.Storage.Streams;

namespace ReachOut
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page, IManageable
    {
        public MapPage()
        {
            this.InitializeComponent();
            MapService.ServiceToken = App.Current.Resources["MapAuthToken"] as string;
            mapControl.Loaded += MapControl_Loaded;
        }

        private async void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.ComplaintList == null)
                return;

            //Ellipse el = new Ellipse();
            //el.Height = 10;
            //el.Width = 10;
            //el.Fill = new SolidColorBrush(Colors.Navy);

            IEnumerable<Tuple<string,Geopoint>> locations = App.ComplaintList.Select((Complaint c) => new Tuple<string, Geopoint>(c.title, new Geopoint(new BasicGeoposition() { Latitude = c.location.Latitude, Longitude = c.location.Longitude })));
            foreach (var loc in locations)
            {
                MapIcon icon = new MapIcon();
                icon.Location = loc.Item2;
                icon.Title = loc.Item1;
                icon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Icons/mapPin.png"));

                mapControl.MapElements.Add(icon);
            }

            Geolocator locator = new Geolocator();
            Geoposition pos = await locator.GetGeopositionAsync();
            mapControl.Center = pos.Coordinate.Point;
            mapControl.ZoomLevel = 10;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PageManager.RegisterPage(this);
        }

        public Dictionary<string, object> SaveState()
        {
            return null;
        }

        public void LoadState(Dictionary<string, object> lastState)
        {
        }

        public bool AllowAppExit()
        {
            return true;
        }
    }
}
