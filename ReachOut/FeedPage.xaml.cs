using ReachOut.Managers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Parse;

namespace ReachOut
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FeedPage : Page, IManageable
    {

        public ObservableCollection<Complaint> Complaints
        { get; set; }

        public FeedPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
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

        public async void LoadState(Dictionary<string, object> lastState)
        {
            loadingScreenPresenter.Visibility = Windows.UI.Xaml.Visibility.Visible;

            try
            {
                var query = new ParseQuery<Complaint>().WhereMatches("heatCount","1");
                IEnumerable<Complaint> list = await query.FindAsync();
                Complaints = new ObservableCollection<Complaint>(list);
                App.ComplaintList = list.ToList();
                this.DataContext = this;
            }
            catch
            {
                Complaints = new ObservableCollection<Complaint>();
            }

            loadingScreenPresenter.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        public bool AllowAppExit()
        {
            return true;
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            PageManager.NavigateTo(typeof(AddComplaintPage), null, NavigationType.Default);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            PageManager.NavigateTo(typeof(MapPage), null, NavigationType.Default);
        }
    }
}
