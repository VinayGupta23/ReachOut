using ReachOut.Managers;
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
using ReachOut.DataModel;
using Windows.Devices.Geolocation;
using Windows.UI.ViewManagement;
using Parse;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace ReachOut
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddComplaintPage : Page, IManageable
    {
        public AddComplaintPage()
        {
            this.InitializeComponent();
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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            PageManager.NavigateBack();
        }

        private async void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            StatusBar bar = StatusBar.GetForCurrentView();
            bar.ProgressIndicator.ProgressValue = null;
            await bar.ProgressIndicator.ShowAsync();

            Complaint c = new Complaint();
            c.title = titleBox.Text;
            c.description = descBox.Text;
            c.category = comboBox.SelectedValue as string;
            Geolocator loc = new Geolocator();
            Geoposition pos = await loc.GetGeopositionAsync();
            ParseGeoPoint gp = new ParseGeoPoint(pos.Coordinate.Latitude, pos.Coordinate.Longitude);
            c.location = gp;
            c.status = "Pending";
            c.heatCount = "1";
            await c.SaveAsync();

            await bar.ProgressIndicator.HideAsync();
            PageManager.NavigateBack();
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
